using BotOfScreenShots_Application.Struct;
using Microsoft.CSharp;
using Newtonsoft.Json;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace BotOfScreenShots_Application
{
    public class ProfileCompiler : Profile
    {
        private readonly CompilerParameters _compilerParams;
        private CompilerResults _compilerResult;
        private CodeElements _codeElements;//{ "System.dll", "System.Windows.Forms.dll", "System.Drawing.dll", "BotOfScreenShots_Algorithms.dll", "System.Threading.dll" }
        private bool _isBuilded;

        [JsonIgnore]
        public bool IsBuilded { get => _isBuilded; set => _isBuilded = value; }
        private new string Code { get => ConverCode(base.Code); }

        [JsonConstructor]
        private ProfileCompiler(int id, string name) : base(id, name) { }

        public ProfileCompiler(bool isFileToCreate) : base(isFileToCreate)
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

        public void Build()
        {
            _compilerParams.ReferencedAssemblies.AddRange(_codeElements.References);
            CSharpCodeProvider provider = new CSharpCodeProvider();
            _compilerResult = provider.CompileAssemblyFromSource(_compilerParams, new[] { Code });

            //komunikat błędu
            if (_compilerResult.Errors.HasErrors)
            {
                MessageBox.Show(_compilerResult.Errors.ToString());
                return;
            }
            _isBuilded = true;
        }

        public void Run()
        {
            if (_isBuilded == false)
                Build();

            Module module = _compilerResult.CompiledAssembly.GetModules()[0];
            if (module != null)
            {
                Type moduleType = module.GetType(_codeElements.Namespace);
                if (moduleType != null)
                {
                    MethodInfo methodInfo = moduleType.GetMethod(_codeElements.MainClass);
                    if (methodInfo != null)
                    {
                        methodInfo.Invoke(null, null);
                    }
                }
            }
        }

        private void FindCodeElements(string code)
        {
            _codeElements = new CodeElements();
            string[] codeArray = code.Split(';');
            List<string> references = new List<string>(codeArray.Length);
            bool isMainMethodExist = false;

            foreach (string codeLine in codeArray)
            {
                if (codeLine.Contains("using "))
                    references.Add(codeLine.Trim(' ').Remove(0, 5) + ".dll");
                else if (codeLine.Contains("namespace "))
                    _codeElements.Namespace = codeLine.Trim(' ').Remove(0, 9);
                else if (!isMainMethodExist)
                {
                    if (codeLine.Contains("class "))
                        _codeElements.MainClass = codeLine.Trim(' ').Remove(0, 5);
                    else if (codeLine.Contains("public static void Main()"))
                    {
                        if (_codeElements.MainClass != string.Empty)
                            isMainMethodExist = true;
                    }
                }
            }
            _codeElements.References = references.ToArray();
        }

        private string ConverCode(string code)
        {
            FindCodeElements(code);

            //if (IsDeveloperMode)

            return null;
        }
    }
}
