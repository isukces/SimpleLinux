using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace iSukces.SimpleLinux.Docker
{
    public class DockerfileBuilder : IShaSource
    {
        private static void AddToZip(ZipArchive zip, IFileCreateRequest request)
        {
            var file = zip.CreateEntry(request.File.FullName);
            if (request.LastWriteTime != null)
                file.LastWriteTime = request.LastWriteTime.Value;
            using(var zipEntryStream = file.Open())
            {
                var bytes = request.Content?.GetBytes() ?? new byte[0];
                zipEntryStream.Write(bytes, 0, bytes.Length);
            }
        }

        public Sha1Code GetSha1()
        {
            IEnumerable<string> codes()
            {
                yield return Code.GetSha1().Base64;
                foreach (var i in ContentFiles) yield return i.GetSha1().Base64;
            }

            var code  = string.Join(" ", codes());
            var code2 = code.CreateSha1();
            return code2;
        }

        public byte[] GetZippedContent(bool includeDockerFile = false)
        {
            using(var m = new MemoryStream())
            {
                using(var zip = new ZipArchive(m, ZipArchiveMode.Create))
                {
                    foreach (var request in ContentFiles) AddToZip(zip, request);

                    if (includeDockerFile)
                    {
                        var request = new FileCreateRequest("Dockerfile", Code);
                        AddToZip(zip, request);
                    }
                }

                return m.ToArray();
            }
        }

        [Obsolete]
        public void WithCode(IEnumerable<string> lines)
        {
            Code = new DockerfileScriptBuilder();
            foreach (var i in lines)
                Code.WriteLine(i);
        }


        // public string ZippedContentTemporaryFile { get; set; } = "__dockerfile_content__.zip";

        public DockerfileScriptBuilder Code { get; set; }

        public IList<IFileCreateRequest> ContentFiles { get; } = new List<IFileCreateRequest>();
    }
}