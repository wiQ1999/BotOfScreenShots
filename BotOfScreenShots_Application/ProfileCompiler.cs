using Microsoft.CSharp;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Forms;

namespace BotOfScreenShots_Application
{
    public class ProfileCompiler : Profile
    {
        #region prop

        const string STARTINGCODE =
             @"namespace " + NAMESPACE
            + "{"
            + "static class " + MAINCLASS
            + "{";
        const string ENDINGCODE =
             @"}"
            + "}";
        const string NAMESPACE = "BoSSCodeArea";
        const string MAINCLASS = "Program";

        private readonly IList<string> _startignRefferences = new ReadOnlyCollection<string>(new[]
        {
            "System.dll"
        });
        private readonly CompilerParameters _compilerParams;

        private CompilerResults _compilerResult;
        private List<string> _references;
        private bool _isBuilded;

        public List<string> References { get => _references; set => _references = value; }
        [JsonIgnore]
        public bool IsBuilded { get => _isBuilded; set { _isBuilded = value; Save(); } }
        [JsonIgnore]
        public new string Code { get => STARTINGCODE + " \n" + base.Code + " \n" + ENDINGCODE; }

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
            _isBuilded = false;
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
            _references = (List<string>)_startignRefferences;
            _isBuilded = false;
        }

        #endregion

        public void Build()
        {
            if (!_isBuilded)
                _isBuilded = true;

            _compilerParams.ReferencedAssemblies.AddRange(_references.ToArray());
            CSharpCodeProvider provider = new CSharpCodeProvider();
            _compilerResult = provider.CompileAssemblyFromSource(_compilerParams, Code);

            if (_compilerResult.Errors.HasErrors)
            {
                MessageBox.Show(_compilerResult.Errors.ToString());
                return;
            }
            _isBuilded = true;
        }

        public void Run()
        {
            if (!_isBuilded)
                Build();

            Module module = _compilerResult.CompiledAssembly.GetModules()[0];
            if (module != null)
            {
                Type moduleType = module.GetType(NAMESPACE);
                if (moduleType != null)
                {
                    MethodInfo methodInfo = moduleType.GetMethod(MAINCLASS);
                    if (methodInfo != null)
                    {
                        methodInfo.Invoke(null, null);
                    }
                }
            }
        }

        //private void FindCodeElements()
        //{
        //    string[] codeArray = Code.Split(';');
        //    List<string> references = new List<string>(codeArray.Length);
        //    bool isMainMethodExist = false;

        //    foreach (string codeLine in codeArray)
        //    {
        //        if (codeLine.Contains("using "))
        //            references.Add(codeLine.Trim(' ').Remove(0, 5) + ".dll");
        //        else if (codeLine.Contains("namespace "))
        //            _codeElements.Namespace = codeLine.Trim(' ').Remove(0, 9);
        //        else if (!isMainMethodExist)
        //        {
        //            if (codeLine.Contains("class "))
        //                _codeElements.MainClass = codeLine.Trim(' ').Remove(0, 5);
        //            else if (codeLine.Contains("public static void Main()"))
        //            {
        //                if (_codeElements.MainClass != string.Empty)
        //                    isMainMethodExist = true;
        //            }
        //        }
        //    }
        //    _codeElements.References = references.ToArray();
        //}

        //private void ConverCode()
        //{
        //    //FindCodeElements();
        //    _isBuilded = true;
        //}
    }
}
