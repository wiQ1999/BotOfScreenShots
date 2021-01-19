using Microsoft.CSharp;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BotOfScreenShots_Application
{
    public class ProfileCompiler : Profile
    {
        #region prop

        public static bool IsCodeOnFlyCompleted;

        const string NAMESPACE = "BoSSCodeArea";
        const string MAINCLASS = "Program";
        const string HEADERCODE =
            "namespace " + NAMESPACE + "\r\n" +
            "{\r\n" +
            "static class " + MAINCLASS + "\r\n" +
            "{\r\n";
        const string BOTTOMCODE =
            "}\r\n" + 
            "}";

        private readonly IList<string> _startignRefferences = new ReadOnlyCollection<string>(new[]
        {
            "System.dll",
            "System.Threading.dll",
            "System.Windows.Forms.dll",
            "BotOfScreenShots_Algorithms.dll"
        });
        private readonly CompilerParameters _compilerParams;
        private Thread _codeOnFlyWorker;
        private CompilerResults _compilerResult;
        private List<string> _references;

        public List<string> References { get => _references; set => _references = value; }
        [JsonIgnore]
        public new string Code { get => TransformReferences() + "\r\n" + HEADERCODE + GetCodeProperties() + base.Code + "\r\n" + BOTTOMCODE; }

        #endregion

        #region ctor

        [JsonConstructor]
        private ProfileCompiler(int id, string name) : base(id, name)
        {
            _compilerParams = new CompilerParameters
            {
                GenerateInMemory = true,
                TreatWarningsAsErrors = false,
                GenerateExecutable = false,
                CompilerOptions = "/optimize"
            };
        }

        public ProfileCompiler(bool isFileToCreate) : base(isFileToCreate)
        {
            _compilerParams = new CompilerParameters
            {
                GenerateInMemory = true,
                TreatWarningsAsErrors = false,
                GenerateExecutable = false,
                CompilerOptions = "/optimize"
            };
            _references = new List<string>();
            foreach (string refference in _startignRefferences)
                _references.Add(refference);
        }

        #endregion

        /// <summary>
        /// Overwrites thread responsible for CodeOnFly
        /// </summary>
        private void CreateCodeOnFlyWorker()
        {
            _codeOnFlyWorker = new Thread(new ThreadStart(CodeOnFly))
            {
                IsBackground = true
            };
        }

        /// <summary>
        /// Delegate method uses to run C# code and catch exceptions
        /// </summary>
        private void CodeOnFly()
        {
            IsCodeOnFlyCompleted = false;
            try
            {
                MethodInfo methodInfo = _compilerResult.CompiledAssembly.GetModules()[0].GetType(NAMESPACE + "." + MAINCLASS).GetMethod("Main");
                if (methodInfo == null)
                    throw new Exception("Nie znaleziono metody \"Main\" jako punktu wejścia.");
                methodInfo.Invoke(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                IsCodeOnFlyCompleted = true;
                Abort();
            }
        }

        /// <summary>
        /// Builds code by C# compiler
        /// </summary>
        public bool Build()
        {
            _compilerParams.ReferencedAssemblies.AddRange(_references.ToArray());
            CSharpCodeProvider provider = new CSharpCodeProvider();
            _compilerResult = provider.CompileAssemblyFromSource(_compilerParams, Code);

            if (_compilerResult.Errors.HasErrors)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (CompilerError error in _compilerResult.Errors)
                    stringBuilder.AppendLine(error.ErrorText);

                MessageBox.Show(stringBuilder.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// Runs code and trigger Build method if it is necessary
        /// </summary>
        public bool Run()
        {
            if (Build())
            {
                CreateCodeOnFlyWorker();
                _codeOnFlyWorker.Start();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deletes living worker
        /// </summary>
        public void Abort()
        {
            if (_codeOnFlyWorker.IsAlive)
                _codeOnFlyWorker.Abort();
        }

        /// <summary>
        /// Transforms references to the code type
        /// </summary>
        /// <returns>Transformed string with all usings from references</returns>
        private string TransformReferences()
        {
            StringBuilder resultReferences = new StringBuilder();

            foreach (string reference in _references)
            {
                if (!reference.Contains(".dll"))
                    MessageBox.Show("Incorrect library " + reference);
                else
                    resultReferences.AppendLine($"using {reference.Remove(reference.Length - 4)};");
            }

            return resultReferences.ToString(); ;
        }

        /// <summary>
        /// Create and get properties of algorithms
        /// </summary>
        /// <returns>Code properties</returns>
        private string GetCodeProperties()
        {
            return $"public static SameImage SameImage = new SameImage({MainForm.WorkArea.X}, {MainForm.WorkArea.Y}, {MainForm.WorkArea.Width}, {MainForm.WorkArea.Height});\r\n" +
                $"public static SimilarImage SimilarImage = new SimilarImage({MainForm.WorkArea.X}, {MainForm.WorkArea.Y}, {MainForm.WorkArea.Width}, {MainForm.WorkArea.Height});\r\n" +
                $"public static string Path = @\"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{LocalPath.Remove(0, 1)}\\\";\r\n";
        }
    }
}
