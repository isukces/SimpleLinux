using iSukces.SimpleLinux.AutoCode.Generators;

namespace iSukces.SimpleLinux.AutoCode
{
    internal static class CurlSetup
    {
        public static void Add(EnumsGenerator enumsGenerator)
        {
            Add_Curl(enumsGenerator);
        }

        private static void Add_Curl(EnumsGenerator enumsGenerator)
        {
            // SOURCE https://www.mit.edu/afs.new/sipb/user/ssen/src/curl-7.11.1/docs/curl.html
            const string desc = @"
-a/--append
When used in an FTP upload, this will tell curl to append to the target file instead of overwriting it.

-A/--user-agent <agent string>
Specify the User-Agent string to send to the HTTP server.

--anyauth
Tells curl to figure out authentication method by itself, and use the most secure one the remote site claims it supports.

-b/--cookie <name=$cookie value>
 Pass the data to the HTTP server as a cookie. 

-B/--use-ascii
Use ASCII transfer when getting an FTP file or LDAP info.

--basic
Tells curl to use HTTP Basic authentication. 

--ciphers <list of ciphers>

Specifies which ciphers to use in the connection.

--compressed
Request a compressed response using one of the algorithms libcurl supports, and return the uncompressed document


--connect-timeout <seconds>
Maximum time in seconds that you allow the connection to the server to take. 


-c/--cookie-jar <file name>
Specify to which file you want curl to write all cookies after a completed operation.

-C/--continue-at <offset>
Continue/Resume a previous file transfer at the given offset.

--create-dirs
When used in conjunction with the -o option, curl will create the necessary local directory hierarchy as needed. 

--crlf
(FTP) Convert LF to CRLF in upload.

 
-d/--data <data>
(HTTP) Sends the specified data in a POST request to the HTTP server, in a way that can emulate as if a user has filled in a HTML form and pressed the submit button.


--data-binary <data>
(HTTP) This posts data in a similar manner as --data-ascii does, although when using this option the entire context of the posted data is kept as-is.

--digest
(HTTP) Enables HTTP Digest authentication.

--disable-epsv
(FTP) Tell curl to disable the use of the EPSV command when doing passive FTP transfers.


-D/--dump-header <fileName>/$dump-header-file-name
Write the protocol headers to the specified file.  

-e/--referer <referer page url>
(HTTP) Sends the ""Referer Page"" information to the HTTP server.

--egd-file <fileName>
(HTTPS) Specify the path name to the Entropy Gathering Daemon socket.

--cert-type <type>
(SSL) Tells curl what certificate type the provided certificate is in. PEM, DER and ENG are recognized types.

--cacert <CA certificate>
(HTTPS) Tells curl to use the specified certificate file to verify the peer.

--capath <CA certificate directory>
(HTTPS) Tells curl to use the specified certificate directory to verify the peer. 

-f/--fail
(HTTP) Fail silently (no output at all) on server errors.

--ftp-create-dirs
(FTP) When an FTP URL/operation uses a path that doesn't currently exist on the server, the standard behavior of curl is to fail.


--ftp-pasv
(FTP) Use PASV when transfering.

--ftp-ssl
(FTP) Make the FTP connection switch to use SSL/TLS.


-F/--form <name=content>
(HTTP) This lets curl emulate a filled in form in which a user has pressed the submit button.

-g/--globoff
This option switches off the ""URL globbing parser"". 

-G/--get
When used, this option will make all data specified with -d/--data or --data-binary to be used in a HTTP GET request instead of the POST request that otherwise would be used.


-H/--header <header>
(HTTP) Extra header to use when getting a web page. 


-i/--include
(HTTP) Include the HTTP-header in the output. 

-I/--head
(HTTP/FTP/FILE) Fetch the HTTP-header only! HTTP-servers feature the command HEAD which this uses to get nothing but the header of a document.

-j/--junk-session-cookies
(HTTP) When curl is told to read cookies from a given file, this option will make it discard all ""session cookies"".

 -k/--insecure
(SSL) This option explicitly allows curl to perform ""insecure"" SSL connections and transfers.
 
--key <Private key file name>
(SSL) Private key file name


-K/--config <config file>
Specify which config file to read curl arguments from. 

--limit-rate <speed>
Specify the maximum transfer rate you want curl to use.

-l/--list-only
(FTP) When listing an FTP directory, this switch forces a name-only view. 

-L/--location
(HTTP/HTTPS) If the server reports that the requested page has a different location (indicated with the header line Location:) this flag will let curl attempt to reattempt the get on the new place.  

--location-trusted
(HTTP/HTTPS) Like -L/--location,

--max-filesize <bytes>
Specify the maximum size (in bytes) of a file to download. 


-m/--max-time <seconds>
Maximum time in seconds that you allow the whole operation to take. 

-o/--output <output file>/$output file
Write output to <file> instead of stdout. 

-R/--remote-time
When used, this will make libcurl attempt to figure out the timestamp of the remote file, and if that is available make the local file get that same timestamp.

-s/--silent
Silent mode. Don't show progress meter or error messages. Makes Curl mute.

-S/--show-error
When used with -s it makes curl show error message if it fails.

-T/--upload-file <file>
This transfers the specified local file to the remote URL.

--url <URL>
Specify a URL to fetch.

-v/--verbose
Makes the fetching more verbose/talkative.


-0/--http1.0
(HTTP) Forces curl to issue its requests using HTTP 1.0 instead of using its internally preferred: HTTP 1.1.

-1/--tlsv1
(HTTPS) Forces curl to use TSL version 1 when negotiating with a remote TLS server.

-2/--sslv2
(HTTPS) Forces curl to use SSL version 2 when negotiating with a remote SSL server.

-3/--sslv3
(HTTPS) Forces curl to use SSL version 3 when negotiating with a remote SSL server.

-4/--ipv4
If libcurl is capable of resolving an address to multiple IP versions (which it is if it is ipv6-capable), this option tells libcurl to resolve names to IPv4 addresses only. (Added in 7.10.8)

-6/--ipv6
If libcurl is capable of resolving an address to multiple IP versions (which it is if it is ipv6-capable), this option tells libcurl to resolve names to IPv6 addresses only. (Added in 7.10.8)

-#/--progress-bar
Make curl display progress information as a progress bar instead of the default statistics.
";
            
            var item = enumsGenerator
                .WithEnum("Curl", desc, ParserKind.Style1)
                .WithStringValue("--user-agent", "Agent")
                .WithStringValue("-b", "cookie value")
                .WithStringValue("--ciphers", "ciphers", true)
                .WithIntegerValue("--connect-timeout", "timeout seconds")
                .WithStringValue("-c", "cookies file")
                .WithIntegerValue("--continue-at")
                .WithStringValue("-d", "data")
                .WithStringValue("--data-binary", "data")
                .WithStringValue("--dump-header", "target file")
                .WithStringValue("--referer", "referer page url")
                .WithStringValue("--egd-file")
                .WithEnumValue("--cert-type", "PEM,DER,ENG".Split(','))
                .WithStringValue("--cacert")
                .WithStringValue("--capath")
                .WithStringValue("--form")
                .WithStringValue("--header")
                .WithStringValue("--key")
                .WithStringValue("--config")
                .WithStringValue("--limit-rate")
                .WithIntegerValue("--max-filesize")
                .WithIntegerValue("--max-time")
                .WithStringValue("-o")
                .WithStringValue("-T")
                .WithStringValue("--url");

            item.Names.OptionsContainerClassName = nameof(CurlCommand);
            CommonSetup(item);
            // add support for -E, --interface, --key-type, --krb4 
            // -n/--netrc, --netrc-optional
            // --negotiate, -N/--no-buffer --ntlm
            // -O/--remote-name
            // --pass <phrase>
            // --proxy-ntlm
            // -p/--proxytunnel
            // -P/--ftp-port <address>
            // -q
            // -Q/--quote <comand>
            // --random-file <file>
            // -r/--range <range>
            // --socks <host[:port]>, --stderr <file>, -t/--telnet-option <OPT=val>
            // --trace <file>, --trace-ascii <file>, 
            // -u/--user <user:password>, -U/--proxy-user <user:password>
            // -w/--write-out <format>
            // -x/--proxy <proxyhost[:port]>
            // -X/--request <command>
            // -y/--speed-time <time>
            // -Y/--speed-limit <speed>
            // -z/--time-cond <date expression>
            // -Z/--max-redirs <num>
        }

        private static void CommonSetup(EnumsGeneratorItem item)
        {
            // OnelineLinuxCommand
            item.FilenameMaker = new TemplateFilenameMaker("{0}\\_shell\\{1}\\{2}");
        }
    }
}