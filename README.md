# Text-Compression

A small Windows app that compresses Arabic text by storing each character in 6 bits instead of 16, so a text takes a little over a third of its usual size. Written in C# with WPF on .NET Framework 4.5; the v1.0.0 interface is in Arabic (ضغط النصوص).

## Versions

| Version | What it is |
|---|---|
| v2.0.0 | An experiment on top of the 6-bit codes: **Compress** saves the `.ctxt` file, then runs arithmetic coding (`BigInteger`, 1000-digit precision) over the codes, decodes them back and shows the restored text in a message box. |
| v1.0.0 | The compressor: **اضغط** (compress) the typed text or **اضغط ملف** (compress a file) to a `.ctxt` file, then **فك الضغط** (decompress) it back into the window or **فك الضغط الى ملف** (decompress to a `.txt` file) with the encoding you pick: ASCII, BigEndianUnicode, Unicode, UTF32, UTF7 or UTF8. |

## How it works

Each character gets a 6-bit code: space, the Arabic letters (with أ إ آ ى ة ء ؤ ئ), the digits, the diacritics, `،` `.` `(` `)` `@` `#`, tab and new line. The codes are packed into 16-bit numbers and written to the `.ctxt` file after a short header. Characters outside that table are dropped, so English text doesn't survive the trip.

The `notes` folder holds the design notes: the 6-bit code table (`Code.txt`, saved in Windows-1256), the powers of two used to pack the bits, and the language tags.

## Requirements

Windows with .NET Framework 4.5 or later. Windows 8, 10 and 11 already include it.

## Usage

Download the `.7z` file of the version you want from [Releases](https://github.com/Mohammad-Diab/Text-Compression/releases), extract it, and run the `.exe` inside (`WpfApplication10.exe` in v1.0.0, `Text Compression.exe` in v2.0.0). There is no installer.

The exe is not signed, so Windows SmartScreen may warn the first time you run it: click **More info**, then **Run anyway**.

## Building

```
git clone https://github.com/Mohammad-Diab/Text-Compression.git
cd Text-Compression
git checkout v2.0.0
```

Open the `.sln` file in Visual Studio and build, or run:

```
MSBuild "Text Compression.sln" /p:Configuration=Release
```

(`WpfApplication10.sln` at the v1.0.0 tag.) The exe is written to `Text Compression\bin\Release`.

The project targets .NET Framework 4.5. Recent Visual Studio versions don't ship its reference assemblies; if the build stops with `MSB3644`, extract the [Microsoft.NETFramework.ReferenceAssemblies.net45](https://www.nuget.org/packages/Microsoft.NETFramework.ReferenceAssemblies.net45) NuGet package and point MSBuild at its `build` folder:

```
MSBuild "Text Compression.sln" /p:Configuration=Release /p:TargetFrameworkRootPath=<package>\build
```

## Author

Mohammad Diab

## License

[Apache 2.0](LICENSE)
