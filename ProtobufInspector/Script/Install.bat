rem script to copy over the files
COPY /Y "%~dp0\ProtobufInspector.dll" "%USERPROFILE%\AppData\Local\Programs\Fiddler\Inspectors"
COPY /Y "%~dp0\protobuf-net.dll" "%USERPROFILE%\AppData\Local\Programs\Fiddler\Inspectors"
COPY /Y "%~dp0\Newtonsoft.Json.dll" "%USERPROFILE%\AppData\Local\Programs\Fiddler\Inspectors"