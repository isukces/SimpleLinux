// ReSharper disable All
using iSukces.SimpleLinux;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace iSukces.SimpleLinux
{
    public partial class CurlCommand
    {
        public IEnumerable<string> GetCodeItems(OptionPreference preferLongNames = OptionPreference.Short)
        {
            // -a, --append: When used in an FTP upload, this will tell curl to append to the target file instead of overwriting it.
            if ((Flags & CurlFlags.Append) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--append" : "-a";
            // --anyauth: Tells curl to figure out authentication method by itself, and use the most secure one the remote site claims it supports.
            if ((Flags & CurlFlags.Anyauth) != 0)
                yield return "--anyauth";
            // -B, --use-ascii: Use ASCII transfer when getting an FTP file or LDAP info.
            if ((Flags & CurlFlags.UseAscii) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--use-ascii" : "-B";
            // --basic: Tells curl to use HTTP Basic authentication.
            if ((Flags & CurlFlags.Basic) != 0)
                yield return "--basic";
            // --compressed: Request a compressed response using one of the algorithms libcurl supports, and return the uncompressed document
            if ((Flags & CurlFlags.Compressed) != 0)
                yield return "--compressed";
            // --create-dirs: When used in conjunction with the -o option, curl will create the necessary local directory hierarchy as needed.
            if ((Flags & CurlFlags.CreateDirs) != 0)
                yield return "--create-dirs";
            // --crlf: (FTP) Convert LF to CRLF in upload.
            if ((Flags & CurlFlags.Crlf) != 0)
                yield return "--crlf";
            // --digest: (HTTP) Enables HTTP Digest authentication.
            if ((Flags & CurlFlags.Digest) != 0)
                yield return "--digest";
            // --disable-epsv: (FTP) Tell curl to disable the use of the EPSV command when doing passive FTP transfers.
            if ((Flags & CurlFlags.DisableEpsv) != 0)
                yield return "--disable-epsv";
            // -f, --fail: (HTTP) Fail silently (no output at all) on server errors.
            if ((Flags & CurlFlags.Fail) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--fail" : "-f";
            // --ftp-create-dirs: (FTP) When an FTP URL/operation uses a path that doesn't currently exist on the server, the standard behavior of curl is to fail.
            if ((Flags & CurlFlags.FtpCreateDirs) != 0)
                yield return "--ftp-create-dirs";
            // --ftp-pasv: (FTP) Use PASV when transfering.
            if ((Flags & CurlFlags.FtpPasv) != 0)
                yield return "--ftp-pasv";
            // --ftp-ssl: (FTP) Make the FTP connection switch to use SSL/TLS.
            if ((Flags & CurlFlags.FtpSsl) != 0)
                yield return "--ftp-ssl";
            // -g, --globoff: This option switches off the "URL globbing parser".
            if ((Flags & CurlFlags.Globoff) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--globoff" : "-g";
            // -G, --get: When used, this option will make all data specified with -d/--data or --data-binary to be used in a HTTP GET request instead of the POST request that otherwise would be used.
            if ((Flags & CurlFlags.Get) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--get" : "-G";
            // -i, --include: (HTTP) Include the HTTP-header in the output.
            if ((Flags & CurlFlags.Include) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--include" : "-i";
            // -I, --head: (HTTP/FTP/FILE) Fetch the HTTP-header only! HTTP-servers feature the command HEAD which this uses to get nothing but the header of a document.
            if ((Flags & CurlFlags.Head) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--head" : "-I";
            // -j, --junk-session-cookies: (HTTP) When curl is told to read cookies from a given file, this option will make it discard all "session cookies".
            if ((Flags & CurlFlags.JunkSessionCookies) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--junk-session-cookies" : "-j";
            // -k, --insecure: (SSL) This option explicitly allows curl to perform "insecure" SSL connections and transfers.
            if ((Flags & CurlFlags.Insecure) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--insecure" : "-k";
            // -l, --list-only: (FTP) When listing an FTP directory, this switch forces a name-only view.
            if ((Flags & CurlFlags.ListOnly) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--list-only" : "-l";
            // -L, --location: (HTTP/HTTPS) If the server reports that the requested page has a different location (indicated with the header line Location:) this flag will let curl attempt to reattempt the get on the new place.
            if ((Flags & CurlFlags.Location) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--location" : "-L";
            // --location-trusted: (HTTP/HTTPS) Like -L/--location,
            if ((Flags & CurlFlags.LocationTrusted) != 0)
                yield return "--location-trusted";
            // -R, --remote-time: When used, this will make libcurl attempt to figure out the timestamp of the remote file, and if that is available make the local file get that same timestamp.
            if ((Flags & CurlFlags.RemoteTime) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--remote-time" : "-R";
            // -s, --silent: Silent mode. Don't show progress meter or error messages. Makes Curl mute.
            if ((Flags & CurlFlags.Silent) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--silent" : "-s";
            // -S, --show-error: When used with -s it makes curl show error message if it fails.
            if ((Flags & CurlFlags.ShowError) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--show-error" : "-S";
            // -v, --verbose: Makes the fetching more verbose/talkative.
            if ((Flags & CurlFlags.Verbose) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--verbose" : "-v";
            // -0, --http1.0: (HTTP) Forces curl to issue its requests using HTTP 1.0 instead of using its internally preferred: HTTP 1.1.
            if ((Flags & CurlFlags.Http10) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--http1.0" : "-0";
            // -1, --tlsv1: (HTTPS) Forces curl to use TSL version 1 when negotiating with a remote TLS server.
            if ((Flags & CurlFlags.Tlsv1) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--tlsv1" : "-1";
            // -2, --sslv2: (HTTPS) Forces curl to use SSL version 2 when negotiating with a remote SSL server.
            if ((Flags & CurlFlags.Sslv2) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--sslv2" : "-2";
            // -3, --sslv3: (HTTPS) Forces curl to use SSL version 3 when negotiating with a remote SSL server.
            if ((Flags & CurlFlags.Sslv3) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--sslv3" : "-3";
            // -4, --ipv4: If libcurl is capable of resolving an address to multiple IP versions (which it is if it is ipv6-capable), this option tells libcurl to resolve names to IPv4 addresses only. (Added in 7.10.8)
            if ((Flags & CurlFlags.Ipv4) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--ipv4" : "-4";
            // -6, --ipv6: If libcurl is capable of resolving an address to multiple IP versions (which it is if it is ipv6-capable), this option tells libcurl to resolve names to IPv6 addresses only. (Added in 7.10.8)
            if ((Flags & CurlFlags.Ipv6) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--ipv6" : "-6";
            // -#, --progress-bar: Make curl display progress information as a progress bar instead of the default statistics.
            if ((Flags & CurlFlags.ProgressBar) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--progress-bar" : "-#";
            // -A, --user-agent =agent string: Specify the User-Agent string to send to the HTTP server.
            if (!string.IsNullOrEmpty(UserAgent))
            {
                yield return "--user-agent";
                yield return UserAgent;
            }
            // -b, --cookie name=cookie value: Pass the data to the HTTP server as a cookie.
            foreach(var pair in CookieValue)
            {
                yield return "--cookie";
                var value = pair.Value;
                yield return $"{pair.Key}={value}";
            }
            // --ciphers list of ciphers: Specifies which ciphers to use in the connection.
            if (!(Ciphers is null) && Ciphers.Count > 0)
            {
                yield return "--ciphers";
                foreach (var ciphersItem in Ciphers)
                    yield return ciphersItem;
            }
            // --connect-timeout =seconds: Maximum time in seconds that you allow the connection to the server to take.
            if (!(ConnectTimeout is null))
            {
                yield return "--connect-timeout";
                yield return ConnectTimeout.Value.ToString(CultureInfo.InvariantCulture);
            }
            // -c, --cookie-jar =file name: Specify to which file you want curl to write all cookies after a completed operation.
            if (!string.IsNullOrEmpty(CookieJar))
            {
                yield return "--cookie-jar";
                yield return CookieJar;
            }
            // -C, --continue-at =offset: Continue/Resume a previous file transfer at the given offset.
            if (!(ContinueAt is null))
            {
                yield return "--continue-at";
                yield return ContinueAt.Value.ToString(CultureInfo.InvariantCulture);
            }
            // -d, --data =data: (HTTP) Sends the specified data in a POST request to the HTTP server, in a way that can emulate as if a user has filled in a HTML form and pressed the submit button.
            if (!string.IsNullOrEmpty(Data))
            {
                yield return "--data";
                yield return Data;
            }
            // --data-binary =data: (HTTP) This posts data in a similar manner as --data-ascii does, although when using this option the entire context of the posted data is kept as-is.
            if (!string.IsNullOrEmpty(DataBinary))
            {
                yield return "--data-binary";
                yield return DataBinary;
            }
            // -D, --dump-header =fileName: Write the protocol headers to the specified file.
            if (!string.IsNullOrEmpty(DumpHeaderFileName))
            {
                yield return "--dump-header";
                yield return DumpHeaderFileName;
            }
            // -e, --referer =referer page url: (HTTP) Sends the "Referer Page" information to the HTTP server.
            if (!string.IsNullOrEmpty(Referer))
            {
                yield return "--referer";
                yield return Referer;
            }
            // --egd-file =fileName: (HTTPS) Specify the path name to the Entropy Gathering Daemon socket.
            if (!string.IsNullOrEmpty(EgdFile))
            {
                yield return "--egd-file";
                yield return EgdFile;
            }
            // --cert-type =type: (SSL) Tells curl what certificate type the provided certificate is in. PEM, DER and ENG are recognized types.
            if (!(CertType is null))
            {
                yield return "--cert-type";
                yield return CertType.Value.ToLinuxValue();
            }
            // --cacert =CA certificate: (HTTPS) Tells curl to use the specified certificate file to verify the peer.
            if (!string.IsNullOrEmpty(Cacert))
            {
                yield return "--cacert";
                yield return Cacert;
            }
            // --capath =CA certificate directory: (HTTPS) Tells curl to use the specified certificate directory to verify the peer.
            if (!string.IsNullOrEmpty(Capath))
            {
                yield return "--capath";
                yield return Capath;
            }
            // -F, --form name=content: (HTTP) This lets curl emulate a filled in form in which a user has pressed the submit button.
            foreach(var pair in Form)
            {
                yield return "--form";
                var value = pair.Value;
                yield return $"{pair.Key}={value}";
            }
            // -H, --header =header: (HTTP) Extra header to use when getting a web page.
            if (!string.IsNullOrEmpty(Header))
            {
                yield return "--header";
                yield return Header;
            }
            // --key =Private key file name: (SSL) Private key file name
            if (!string.IsNullOrEmpty(Key))
            {
                yield return "--key";
                yield return Key;
            }
            // -K, --config =config file: Specify which config file to read curl arguments from.
            if (!string.IsNullOrEmpty(Config))
            {
                yield return "--config";
                yield return Config;
            }
            // --limit-rate =speed: Specify the maximum transfer rate you want curl to use.
            if (!string.IsNullOrEmpty(LimitRate))
            {
                yield return "--limit-rate";
                yield return LimitRate;
            }
            // --max-filesize =bytes: Specify the maximum size (in bytes) of a file to download.
            if (!(MaxFilesize is null))
            {
                yield return "--max-filesize";
                yield return MaxFilesize.Value.ToString(CultureInfo.InvariantCulture);
            }
            // -m, --max-time =seconds: Maximum time in seconds that you allow the whole operation to take.
            if (!(MaxTime is null))
            {
                yield return "--max-time";
                yield return MaxTime.Value.ToString(CultureInfo.InvariantCulture);
            }
            // -o, --output =output file: Write output to <file> instead of stdout.
            if (!string.IsNullOrEmpty(OutputFile))
            {
                yield return "--output";
                yield return OutputFile;
            }
            // -T, --upload-file =file: This transfers the specified local file to the remote URL.
            if (!string.IsNullOrEmpty(UploadFile))
            {
                yield return "--upload-file";
                yield return UploadFile;
            }
            // --url =URL: Specify a URL to fetch.
            if (!string.IsNullOrEmpty(Url))
            {
                yield return "--url";
                yield return Url;
            }
        }

        /// <summary>
        /// --anyauth: Tells curl to figure out authentication method by itself, and use the most secure one the remote site claims it supports.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithAnyauth(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Anyauth, value);
            return this;
        }

        /// <summary>
        /// -a, --append: When used in an FTP upload, this will tell curl to append to the target file instead of overwriting it.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithAppend(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Append, value);
            return this;
        }

        /// <summary>
        /// --ciphers list of ciphers: Specifies which ciphers to use in the connection.
        /// </summary>
        /// <param name="listOfCiphers">ciphers</param>
        public CurlCommand WithAppendCiphers(string[] listOfCiphers)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            if (!(listOfCiphers is null) && listOfCiphers.Length > 0)
                foreach (var tmp in listOfCiphers)
                    Ciphers.Add(tmp);
            return this;
        }

        /// <summary>
        /// --basic: Tells curl to use HTTP Basic authentication.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithBasic(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Basic, value);
            return this;
        }

        /// <summary>
        /// --cacert =CA certificate: (HTTPS) Tells curl to use the specified certificate file to verify the peer.
        /// </summary>
        /// <param name="caCertificate"></param>
        public CurlCommand WithCacert(string caCertificate)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Cacert = caCertificate;
            return this;
        }

        /// <summary>
        /// --capath =CA certificate directory: (HTTPS) Tells curl to use the specified certificate directory to verify the peer.
        /// </summary>
        /// <param name="caCertificateDirectory"></param>
        public CurlCommand WithCapath(string caCertificateDirectory)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Capath = caCertificateDirectory;
            return this;
        }

        /// <summary>
        /// --cert-type =type: (SSL) Tells curl what certificate type the provided certificate is in. PEM, DER and ENG are recognized types.
        /// </summary>
        /// <param name="type"></param>
        public CurlCommand WithCertType(CurlCertTypeValues? type)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            CertType = type;
            return this;
        }

        /// <summary>
        /// --compressed: Request a compressed response using one of the algorithms libcurl supports, and return the uncompressed document
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithCompressed(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Compressed, value);
            return this;
        }

        /// <summary>
        /// -K, --config =config file: Specify which config file to read curl arguments from.
        /// </summary>
        /// <param name="configFile"></param>
        public CurlCommand WithConfig(string configFile)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Config = configFile;
            return this;
        }

        /// <summary>
        /// --connect-timeout =seconds: Maximum time in seconds that you allow the connection to the server to take.
        /// </summary>
        /// <param name="seconds">timeout seconds</param>
        public CurlCommand WithConnectTimeout(int? seconds)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            ConnectTimeout = seconds;
            return this;
        }

        /// <summary>
        /// -C, --continue-at =offset: Continue/Resume a previous file transfer at the given offset.
        /// </summary>
        /// <param name="offset"></param>
        public CurlCommand WithContinueAt(int? offset)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            ContinueAt = offset;
            return this;
        }

        /// <summary>
        /// -c, --cookie-jar =file name: Specify to which file you want curl to write all cookies after a completed operation.
        /// </summary>
        /// <param name="fileName">cookies file</param>
        public CurlCommand WithCookieJar(string fileName)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            CookieJar = fileName;
            return this;
        }

        /// <summary>
        /// -b, --cookie name=cookie value: Pass the data to the HTTP server as a cookie.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cookieValue">cookie value</param>
        public CurlCommand WithCookieValue(string name, string cookieValue)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            CookieValue[name] = cookieValue;
            return this;
        }

        /// <summary>
        /// --create-dirs: When used in conjunction with the -o option, curl will create the necessary local directory hierarchy as needed.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithCreateDirs(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.CreateDirs, value);
            return this;
        }

        /// <summary>
        /// --crlf: (FTP) Convert LF to CRLF in upload.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithCrlf(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Crlf, value);
            return this;
        }

        /// <summary>
        /// -d, --data =data: (HTTP) Sends the specified data in a POST request to the HTTP server, in a way that can emulate as if a user has filled in a HTML form and pressed the submit button.
        /// </summary>
        /// <param name="data">data</param>
        public CurlCommand WithData(string data)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Data = data;
            return this;
        }

        /// <summary>
        /// --data-binary =data: (HTTP) This posts data in a similar manner as --data-ascii does, although when using this option the entire context of the posted data is kept as-is.
        /// </summary>
        /// <param name="data">data</param>
        public CurlCommand WithDataBinary(string data)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            DataBinary = data;
            return this;
        }

        /// <summary>
        /// --digest: (HTTP) Enables HTTP Digest authentication.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithDigest(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Digest, value);
            return this;
        }

        /// <summary>
        /// --disable-epsv: (FTP) Tell curl to disable the use of the EPSV command when doing passive FTP transfers.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithDisableEpsv(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.DisableEpsv, value);
            return this;
        }

        /// <summary>
        /// -D, --dump-header =fileName: Write the protocol headers to the specified file.
        /// </summary>
        /// <param name="filename">target file</param>
        public CurlCommand WithDumpHeaderFileName(string filename)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            DumpHeaderFileName = filename;
            return this;
        }

        /// <summary>
        /// --egd-file =fileName: (HTTPS) Specify the path name to the Entropy Gathering Daemon socket.
        /// </summary>
        /// <param name="filename"></param>
        public CurlCommand WithEgdFile(string filename)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            EgdFile = filename;
            return this;
        }

        /// <summary>
        /// -f, --fail: (HTTP) Fail silently (no output at all) on server errors.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithFail(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Fail, value);
            return this;
        }

        /// <summary>
        /// -F, --form name=content: (HTTP) This lets curl emulate a filled in form in which a user has pressed the submit button.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        public CurlCommand WithForm(string name, string content)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Form[name] = content;
            return this;
        }

        /// <summary>
        /// --ftp-create-dirs: (FTP) When an FTP URL/operation uses a path that doesn't currently exist on the server, the standard behavior of curl is to fail.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithFtpCreateDirs(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.FtpCreateDirs, value);
            return this;
        }

        /// <summary>
        /// --ftp-pasv: (FTP) Use PASV when transfering.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithFtpPasv(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.FtpPasv, value);
            return this;
        }

        /// <summary>
        /// --ftp-ssl: (FTP) Make the FTP connection switch to use SSL/TLS.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithFtpSsl(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.FtpSsl, value);
            return this;
        }

        /// <summary>
        /// -G, --get: When used, this option will make all data specified with -d/--data or --data-binary to be used in a HTTP GET request instead of the POST request that otherwise would be used.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithGet(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Get, value);
            return this;
        }

        /// <summary>
        /// -g, --globoff: This option switches off the "URL globbing parser".
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithGloboff(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Globoff, value);
            return this;
        }

        /// <summary>
        /// -I, --head: (HTTP/FTP/FILE) Fetch the HTTP-header only! HTTP-servers feature the command HEAD which this uses to get nothing but the header of a document.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithHead(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Head, value);
            return this;
        }

        /// <summary>
        /// -H, --header =header: (HTTP) Extra header to use when getting a web page.
        /// </summary>
        /// <param name="header"></param>
        public CurlCommand WithHeader(string header)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Header = header;
            return this;
        }

        /// <summary>
        /// -0, --http1.0: (HTTP) Forces curl to issue its requests using HTTP 1.0 instead of using its internally preferred: HTTP 1.1.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithHttp10(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Http10, value);
            return this;
        }

        /// <summary>
        /// -i, --include: (HTTP) Include the HTTP-header in the output.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithInclude(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Include, value);
            return this;
        }

        /// <summary>
        /// -k, --insecure: (SSL) This option explicitly allows curl to perform "insecure" SSL connections and transfers.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithInsecure(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Insecure, value);
            return this;
        }

        /// <summary>
        /// -4, --ipv4: If libcurl is capable of resolving an address to multiple IP versions (which it is if it is ipv6-capable), this option tells libcurl to resolve names to IPv4 addresses only. (Added in 7.10.8)
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithIpv4(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Ipv4, value);
            return this;
        }

        /// <summary>
        /// -6, --ipv6: If libcurl is capable of resolving an address to multiple IP versions (which it is if it is ipv6-capable), this option tells libcurl to resolve names to IPv6 addresses only. (Added in 7.10.8)
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithIpv6(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Ipv6, value);
            return this;
        }

        /// <summary>
        /// -j, --junk-session-cookies: (HTTP) When curl is told to read cookies from a given file, this option will make it discard all "session cookies".
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithJunkSessionCookies(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.JunkSessionCookies, value);
            return this;
        }

        /// <summary>
        /// --key =Private key file name: (SSL) Private key file name
        /// </summary>
        /// <param name="privateKeyFileName"></param>
        public CurlCommand WithKey(string privateKeyFileName)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Key = privateKeyFileName;
            return this;
        }

        /// <summary>
        /// --limit-rate =speed: Specify the maximum transfer rate you want curl to use.
        /// </summary>
        /// <param name="speed"></param>
        public CurlCommand WithLimitRate(string speed)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            LimitRate = speed;
            return this;
        }

        /// <summary>
        /// -l, --list-only: (FTP) When listing an FTP directory, this switch forces a name-only view.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithListOnly(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.ListOnly, value);
            return this;
        }

        /// <summary>
        /// -L, --location: (HTTP/HTTPS) If the server reports that the requested page has a different location (indicated with the header line Location:) this flag will let curl attempt to reattempt the get on the new place.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithLocation(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Location, value);
            return this;
        }

        /// <summary>
        /// --location-trusted: (HTTP/HTTPS) Like -L/--location,
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithLocationTrusted(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.LocationTrusted, value);
            return this;
        }

        /// <summary>
        /// --max-filesize =bytes: Specify the maximum size (in bytes) of a file to download.
        /// </summary>
        /// <param name="bytes"></param>
        public CurlCommand WithMaxFilesize(int? bytes)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            MaxFilesize = bytes;
            return this;
        }

        /// <summary>
        /// -m, --max-time =seconds: Maximum time in seconds that you allow the whole operation to take.
        /// </summary>
        /// <param name="seconds"></param>
        public CurlCommand WithMaxTime(int? seconds)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            MaxTime = seconds;
            return this;
        }

        /// <summary>
        /// -o, --output =output file: Write output to &lt;file&gt; instead of stdout.
        /// </summary>
        /// <param name="outputFile"></param>
        public CurlCommand WithOutputFile(string outputFile)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            OutputFile = outputFile;
            return this;
        }

        /// <summary>
        /// -#, --progress-bar: Make curl display progress information as a progress bar instead of the default statistics.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithProgressBar(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.ProgressBar, value);
            return this;
        }

        /// <summary>
        /// -e, --referer =referer page url: (HTTP) Sends the "Referer Page" information to the HTTP server.
        /// </summary>
        /// <param name="refererPageUrl">referer page url</param>
        public CurlCommand WithReferer(string refererPageUrl)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Referer = refererPageUrl;
            return this;
        }

        /// <summary>
        /// -R, --remote-time: When used, this will make libcurl attempt to figure out the timestamp of the remote file, and if that is available make the local file get that same timestamp.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithRemoteTime(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.RemoteTime, value);
            return this;
        }

        /// <summary>
        /// -S, --show-error: When used with -s it makes curl show error message if it fails.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithShowError(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.ShowError, value);
            return this;
        }

        /// <summary>
        /// -s, --silent: Silent mode. Don't show progress meter or error messages. Makes Curl mute.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithSilent(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Silent, value);
            return this;
        }

        /// <summary>
        /// -2, --sslv2: (HTTPS) Forces curl to use SSL version 2 when negotiating with a remote SSL server.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithSslv2(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Sslv2, value);
            return this;
        }

        /// <summary>
        /// -3, --sslv3: (HTTPS) Forces curl to use SSL version 3 when negotiating with a remote SSL server.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithSslv3(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Sslv3, value);
            return this;
        }

        /// <summary>
        /// -1, --tlsv1: (HTTPS) Forces curl to use TSL version 1 when negotiating with a remote TLS server.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithTlsv1(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Tlsv1, value);
            return this;
        }

        /// <summary>
        /// -T, --upload-file =file: This transfers the specified local file to the remote URL.
        /// </summary>
        /// <param name="file"></param>
        public CurlCommand WithUploadFile(string file)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            UploadFile = file;
            return this;
        }

        /// <summary>
        /// --url =URL: Specify a URL to fetch.
        /// </summary>
        /// <param name="url"></param>
        public CurlCommand WithUrl(string url)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            Url = url;
            return this;
        }

        /// <summary>
        /// -B, --use-ascii: Use ASCII transfer when getting an FTP file or LDAP info.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithUseAscii(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.UseAscii, value);
            return this;
        }

        /// <summary>
        /// -A, --user-agent =agent string: Specify the User-Agent string to send to the HTTP server.
        /// </summary>
        /// <param name="agentString">Agent</param>
        public CurlCommand WithUserAgent(string agentString)
        {
            // generator : SingleTaskEnumsGenerator.CreateNamedParameters:225
            UserAgent = agentString;
            return this;
        }

        /// <summary>
        /// -v, --verbose: Makes the fetching more verbose/talkative.
        /// </summary>
        /// <param name="value"></param>
        public CurlCommand WithVerbose(bool value = true)
        {
            // generator : SingleTaskEnumsGenerator.MyStruct_AddWithMethod:388
            Flags = Flags.SetOrClear(CurlFlags.Verbose, value);
            return this;
        }

        public CurlFlags Flags { get; set; }

        /// <summary>
        /// -A, --user-agent =agent string: Specify the User-Agent string to send to the HTTP server.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// -b, --cookie name=cookie value: Pass the data to the HTTP server as a cookie.
        /// </summary>
        public IDictionary<string, string> CookieValue { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// --ciphers list of ciphers: Specifies which ciphers to use in the connection.
        /// </summary>
        public IList<string> Ciphers { get; set; } = new List<string>();

        /// <summary>
        /// --connect-timeout =seconds: Maximum time in seconds that you allow the connection to the server to take.
        /// </summary>
        public int? ConnectTimeout { get; set; }

        /// <summary>
        /// -c, --cookie-jar =file name: Specify to which file you want curl to write all cookies after a completed operation.
        /// </summary>
        public string CookieJar { get; set; }

        /// <summary>
        /// -C, --continue-at =offset: Continue/Resume a previous file transfer at the given offset.
        /// </summary>
        public int? ContinueAt { get; set; }

        /// <summary>
        /// -d, --data =data: (HTTP) Sends the specified data in a POST request to the HTTP server, in a way that can emulate as if a user has filled in a HTML form and pressed the submit button.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// --data-binary =data: (HTTP) This posts data in a similar manner as --data-ascii does, although when using this option the entire context of the posted data is kept as-is.
        /// </summary>
        public string DataBinary { get; set; }

        /// <summary>
        /// -D, --dump-header =fileName: Write the protocol headers to the specified file.
        /// </summary>
        public string DumpHeaderFileName { get; set; }

        /// <summary>
        /// -e, --referer =referer page url: (HTTP) Sends the "Referer Page" information to the HTTP server.
        /// </summary>
        public string Referer { get; set; }

        /// <summary>
        /// --egd-file =fileName: (HTTPS) Specify the path name to the Entropy Gathering Daemon socket.
        /// </summary>
        public string EgdFile { get; set; }

        /// <summary>
        /// --cert-type =type: (SSL) Tells curl what certificate type the provided certificate is in. PEM, DER and ENG are recognized types.
        /// </summary>
        public CurlCertTypeValues? CertType { get; set; }

        /// <summary>
        /// --cacert =CA certificate: (HTTPS) Tells curl to use the specified certificate file to verify the peer.
        /// </summary>
        public string Cacert { get; set; }

        /// <summary>
        /// --capath =CA certificate directory: (HTTPS) Tells curl to use the specified certificate directory to verify the peer.
        /// </summary>
        public string Capath { get; set; }

        /// <summary>
        /// -F, --form name=content: (HTTP) This lets curl emulate a filled in form in which a user has pressed the submit button.
        /// </summary>
        public IDictionary<string, string> Form { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// -H, --header =header: (HTTP) Extra header to use when getting a web page.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// --key =Private key file name: (SSL) Private key file name
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// -K, --config =config file: Specify which config file to read curl arguments from.
        /// </summary>
        public string Config { get; set; }

        /// <summary>
        /// --limit-rate =speed: Specify the maximum transfer rate you want curl to use.
        /// </summary>
        public string LimitRate { get; set; }

        /// <summary>
        /// --max-filesize =bytes: Specify the maximum size (in bytes) of a file to download.
        /// </summary>
        public int? MaxFilesize { get; set; }

        /// <summary>
        /// -m, --max-time =seconds: Maximum time in seconds that you allow the whole operation to take.
        /// </summary>
        public int? MaxTime { get; set; }

        /// <summary>
        /// -o, --output =output file: Write output to &lt;file&gt; instead of stdout.
        /// </summary>
        public string OutputFile { get; set; }

        /// <summary>
        /// -T, --upload-file =file: This transfers the specified local file to the remote URL.
        /// </summary>
        public string UploadFile { get; set; }

        /// <summary>
        /// --url =URL: Specify a URL to fetch.
        /// </summary>
        public string Url { get; set; }

    }

    public static partial class CurlExtensions
    {
        public static IEnumerable<string> OptionsToString(this CurlFlags value, OptionPreference preferLongNames = OptionPreference.Short)
        {
            // generator : SingleTaskEnumsGenerator
            // -a, --append: When used in an FTP upload, this will tell curl to append to the target file instead of overwriting it.
            if ((value & CurlFlags.Append) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--append" : "-a";
            // --anyauth: Tells curl to figure out authentication method by itself, and use the most secure one the remote site claims it supports.
            if ((value & CurlFlags.Anyauth) != 0)
                yield return "--anyauth";
            // -B, --use-ascii: Use ASCII transfer when getting an FTP file or LDAP info.
            if ((value & CurlFlags.UseAscii) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--use-ascii" : "-B";
            // --basic: Tells curl to use HTTP Basic authentication.
            if ((value & CurlFlags.Basic) != 0)
                yield return "--basic";
            // --compressed: Request a compressed response using one of the algorithms libcurl supports, and return the uncompressed document
            if ((value & CurlFlags.Compressed) != 0)
                yield return "--compressed";
            // --create-dirs: When used in conjunction with the -o option, curl will create the necessary local directory hierarchy as needed.
            if ((value & CurlFlags.CreateDirs) != 0)
                yield return "--create-dirs";
            // --crlf: (FTP) Convert LF to CRLF in upload.
            if ((value & CurlFlags.Crlf) != 0)
                yield return "--crlf";
            // --digest: (HTTP) Enables HTTP Digest authentication.
            if ((value & CurlFlags.Digest) != 0)
                yield return "--digest";
            // --disable-epsv: (FTP) Tell curl to disable the use of the EPSV command when doing passive FTP transfers.
            if ((value & CurlFlags.DisableEpsv) != 0)
                yield return "--disable-epsv";
            // -f, --fail: (HTTP) Fail silently (no output at all) on server errors.
            if ((value & CurlFlags.Fail) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--fail" : "-f";
            // --ftp-create-dirs: (FTP) When an FTP URL/operation uses a path that doesn't currently exist on the server, the standard behavior of curl is to fail.
            if ((value & CurlFlags.FtpCreateDirs) != 0)
                yield return "--ftp-create-dirs";
            // --ftp-pasv: (FTP) Use PASV when transfering.
            if ((value & CurlFlags.FtpPasv) != 0)
                yield return "--ftp-pasv";
            // --ftp-ssl: (FTP) Make the FTP connection switch to use SSL/TLS.
            if ((value & CurlFlags.FtpSsl) != 0)
                yield return "--ftp-ssl";
            // -g, --globoff: This option switches off the "URL globbing parser".
            if ((value & CurlFlags.Globoff) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--globoff" : "-g";
            // -G, --get: When used, this option will make all data specified with -d/--data or --data-binary to be used in a HTTP GET request instead of the POST request that otherwise would be used.
            if ((value & CurlFlags.Get) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--get" : "-G";
            // -i, --include: (HTTP) Include the HTTP-header in the output.
            if ((value & CurlFlags.Include) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--include" : "-i";
            // -I, --head: (HTTP/FTP/FILE) Fetch the HTTP-header only! HTTP-servers feature the command HEAD which this uses to get nothing but the header of a document.
            if ((value & CurlFlags.Head) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--head" : "-I";
            // -j, --junk-session-cookies: (HTTP) When curl is told to read cookies from a given file, this option will make it discard all "session cookies".
            if ((value & CurlFlags.JunkSessionCookies) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--junk-session-cookies" : "-j";
            // -k, --insecure: (SSL) This option explicitly allows curl to perform "insecure" SSL connections and transfers.
            if ((value & CurlFlags.Insecure) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--insecure" : "-k";
            // -l, --list-only: (FTP) When listing an FTP directory, this switch forces a name-only view.
            if ((value & CurlFlags.ListOnly) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--list-only" : "-l";
            // -L, --location: (HTTP/HTTPS) If the server reports that the requested page has a different location (indicated with the header line Location:) this flag will let curl attempt to reattempt the get on the new place.
            if ((value & CurlFlags.Location) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--location" : "-L";
            // --location-trusted: (HTTP/HTTPS) Like -L/--location,
            if ((value & CurlFlags.LocationTrusted) != 0)
                yield return "--location-trusted";
            // -R, --remote-time: When used, this will make libcurl attempt to figure out the timestamp of the remote file, and if that is available make the local file get that same timestamp.
            if ((value & CurlFlags.RemoteTime) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--remote-time" : "-R";
            // -s, --silent: Silent mode. Don't show progress meter or error messages. Makes Curl mute.
            if ((value & CurlFlags.Silent) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--silent" : "-s";
            // -S, --show-error: When used with -s it makes curl show error message if it fails.
            if ((value & CurlFlags.ShowError) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--show-error" : "-S";
            // -v, --verbose: Makes the fetching more verbose/talkative.
            if ((value & CurlFlags.Verbose) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--verbose" : "-v";
            // -0, --http1.0: (HTTP) Forces curl to issue its requests using HTTP 1.0 instead of using its internally preferred: HTTP 1.1.
            if ((value & CurlFlags.Http10) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--http1.0" : "-0";
            // -1, --tlsv1: (HTTPS) Forces curl to use TSL version 1 when negotiating with a remote TLS server.
            if ((value & CurlFlags.Tlsv1) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--tlsv1" : "-1";
            // -2, --sslv2: (HTTPS) Forces curl to use SSL version 2 when negotiating with a remote SSL server.
            if ((value & CurlFlags.Sslv2) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--sslv2" : "-2";
            // -3, --sslv3: (HTTPS) Forces curl to use SSL version 3 when negotiating with a remote SSL server.
            if ((value & CurlFlags.Sslv3) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--sslv3" : "-3";
            // -4, --ipv4: If libcurl is capable of resolving an address to multiple IP versions (which it is if it is ipv6-capable), this option tells libcurl to resolve names to IPv4 addresses only. (Added in 7.10.8)
            if ((value & CurlFlags.Ipv4) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--ipv4" : "-4";
            // -6, --ipv6: If libcurl is capable of resolving an address to multiple IP versions (which it is if it is ipv6-capable), this option tells libcurl to resolve names to IPv6 addresses only. (Added in 7.10.8)
            if ((value & CurlFlags.Ipv6) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--ipv6" : "-6";
            // -#, --progress-bar: Make curl display progress information as a progress bar instead of the default statistics.
            if ((value & CurlFlags.ProgressBar) != 0)
                yield return preferLongNames == OptionPreference.Long ? "--progress-bar" : "-#";
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CurlFlags SetOrClear(this CurlFlags current, CurlFlags value, bool add)
        {
            if (add)
                return current | value;
            else
                return current & ~value;
        }

        public static string ToLinuxValue(this CurlCertTypeValues value)
        {
            // generator : ShellEnumOptionsGenerator.MakeExtensionMethod:35
            switch (value)
            {
                case CurlCertTypeValues.Pem: return "PEM";
                case CurlCertTypeValues.Der: return "DER";
                case CurlCertTypeValues.Eng: return "ENG";
                default: throw new NotSupportedException();
            }
        }

    }

    [Flags]
    public enum CurlFlags: long
    {
        None = 0,
        /// <summary>
        /// -a, --append: When used in an FTP upload, this will tell curl to append to the target file instead of overwriting it.
        /// </summary>
        Append = 1,
        /// <summary>
        /// --anyauth: Tells curl to figure out authentication method by itself, and use the most secure one the remote site claims it supports.
        /// </summary>
        Anyauth = 2,
        /// <summary>
        /// -B, --use-ascii: Use ASCII transfer when getting an FTP file or LDAP info.
        /// </summary>
        UseAscii = 4,
        /// <summary>
        /// --basic: Tells curl to use HTTP Basic authentication.
        /// </summary>
        Basic = 8,
        /// <summary>
        /// --compressed: Request a compressed response using one of the algorithms libcurl supports, and return the uncompressed document
        /// </summary>
        Compressed = 16,
        /// <summary>
        /// --create-dirs: When used in conjunction with the -o option, curl will create the necessary local directory hierarchy as needed.
        /// </summary>
        CreateDirs = 32,
        /// <summary>
        /// --crlf: (FTP) Convert LF to CRLF in upload.
        /// </summary>
        Crlf = 64,
        /// <summary>
        /// --digest: (HTTP) Enables HTTP Digest authentication.
        /// </summary>
        Digest = 128,
        /// <summary>
        /// --disable-epsv: (FTP) Tell curl to disable the use of the EPSV command when doing passive FTP transfers.
        /// </summary>
        DisableEpsv = 256,
        /// <summary>
        /// -f, --fail: (HTTP) Fail silently (no output at all) on server errors.
        /// </summary>
        Fail = 512,
        /// <summary>
        /// --ftp-create-dirs: (FTP) When an FTP URL/operation uses a path that doesn't currently exist on the server, the standard behavior of curl is to fail.
        /// </summary>
        FtpCreateDirs = 1024,
        /// <summary>
        /// --ftp-pasv: (FTP) Use PASV when transfering.
        /// </summary>
        FtpPasv = 2048,
        /// <summary>
        /// --ftp-ssl: (FTP) Make the FTP connection switch to use SSL/TLS.
        /// </summary>
        FtpSsl = 4096,
        /// <summary>
        /// -g, --globoff: This option switches off the "URL globbing parser".
        /// </summary>
        Globoff = 8192,
        /// <summary>
        /// -G, --get: When used, this option will make all data specified with -d/--data or --data-binary to be used in a HTTP GET request instead of the POST request that otherwise would be used.
        /// </summary>
        Get = 16384,
        /// <summary>
        /// -i, --include: (HTTP) Include the HTTP-header in the output.
        /// </summary>
        Include = 32768,
        /// <summary>
        /// -I, --head: (HTTP/FTP/FILE) Fetch the HTTP-header only! HTTP-servers feature the command HEAD which this uses to get nothing but the header of a document.
        /// </summary>
        Head = 65536,
        /// <summary>
        /// -j, --junk-session-cookies: (HTTP) When curl is told to read cookies from a given file, this option will make it discard all "session cookies".
        /// </summary>
        JunkSessionCookies = 131072,
        /// <summary>
        /// -k, --insecure: (SSL) This option explicitly allows curl to perform "insecure" SSL connections and transfers.
        /// </summary>
        Insecure = 262144,
        /// <summary>
        /// -l, --list-only: (FTP) When listing an FTP directory, this switch forces a name-only view.
        /// </summary>
        ListOnly = 524288,
        /// <summary>
        /// -L, --location: (HTTP/HTTPS) If the server reports that the requested page has a different location (indicated with the header line Location:) this flag will let curl attempt to reattempt the get on the new place.
        /// </summary>
        Location = 1048576,
        /// <summary>
        /// --location-trusted: (HTTP/HTTPS) Like -L/--location,
        /// </summary>
        LocationTrusted = 2097152,
        /// <summary>
        /// -R, --remote-time: When used, this will make libcurl attempt to figure out the timestamp of the remote file, and if that is available make the local file get that same timestamp.
        /// </summary>
        RemoteTime = 4194304,
        /// <summary>
        /// -s, --silent: Silent mode. Don't show progress meter or error messages. Makes Curl mute.
        /// </summary>
        Silent = 8388608,
        /// <summary>
        /// -S, --show-error: When used with -s it makes curl show error message if it fails.
        /// </summary>
        ShowError = 16777216,
        /// <summary>
        /// -v, --verbose: Makes the fetching more verbose/talkative.
        /// </summary>
        Verbose = 33554432,
        /// <summary>
        /// -0, --http1.0: (HTTP) Forces curl to issue its requests using HTTP 1.0 instead of using its internally preferred: HTTP 1.1.
        /// </summary>
        Http10 = 67108864,
        /// <summary>
        /// -1, --tlsv1: (HTTPS) Forces curl to use TSL version 1 when negotiating with a remote TLS server.
        /// </summary>
        Tlsv1 = 134217728,
        /// <summary>
        /// -2, --sslv2: (HTTPS) Forces curl to use SSL version 2 when negotiating with a remote SSL server.
        /// </summary>
        Sslv2 = 268435456,
        /// <summary>
        /// -3, --sslv3: (HTTPS) Forces curl to use SSL version 3 when negotiating with a remote SSL server.
        /// </summary>
        Sslv3 = 536870912,
        /// <summary>
        /// -4, --ipv4: If libcurl is capable of resolving an address to multiple IP versions (which it is if it is ipv6-capable), this option tells libcurl to resolve names to IPv4 addresses only. (Added in 7.10.8)
        /// </summary>
        Ipv4 = 1073741824,
        /// <summary>
        /// -6, --ipv6: If libcurl is capable of resolving an address to multiple IP versions (which it is if it is ipv6-capable), this option tells libcurl to resolve names to IPv6 addresses only. (Added in 7.10.8)
        /// </summary>
        Ipv6 = 2147483648,
        /// <summary>
        /// -#, --progress-bar: Make curl display progress information as a progress bar instead of the default statistics.
        /// </summary>
        ProgressBar = 4294967296
    }

    public enum CurlCertTypeValues
    {
        Pem,
        Der,
        Eng
    }
}
