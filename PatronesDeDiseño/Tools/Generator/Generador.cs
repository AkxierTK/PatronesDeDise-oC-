using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tools.Generator
{
    public class Generador
    {
        public List<string> Content { get; set; }

        public string Path { get; set; }

        public TypeFormat Format { get; set; }

        public TypeCharacter Character { get; set; }

        public void Save()
        {
            string resutl = "";
            resutl = Format == TypeFormat.Json?GetJson(): GetPipe() ;

            if (Character == TypeCharacter.Uppercase) resutl = resutl.ToUpper() ;
            if (Character == TypeCharacter.Lowercase) resutl = resutl.ToLower();

            File.WriteAllText(Path, resutl) ;
        }

        private string GetJson() => JsonSerializer.Serialize(Content);

        private string GetPipe() => Content.Aggregate((accum, current) => accum + "|" + current);

    }
        
}
