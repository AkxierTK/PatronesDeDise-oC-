using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Generator
{
    public class GeneratorDirector
    {
        private IBuilderGenerator _builderGenerator;

        public GeneratorDirector(IBuilderGenerator builderGenerator)
        {
            SetBuilder(builderGenerator);
        }

        public void SetBuilder(IBuilderGenerator builderGenerator)
        {
            _builderGenerator = builderGenerator;
        }

        public void CreateSimpleJson(List<string> content, string path)
        {
            _builderGenerator.Reset();
            _builderGenerator.SetContent(content);
            _builderGenerator.SetPath(path);
            _builderGenerator.SetFormat(TypeFormat.Json);
        }

        public void CreateSimplePipe(List<string> content, string path)
        {
            _builderGenerator.Reset();
            _builderGenerator.SetContent(content);
            _builderGenerator.SetPath(path);
            _builderGenerator.SetFormat(TypeFormat.Pipes);
            _builderGenerator.SetCharacter(TypeCharacter.Uppercase);
        }

    }
}
