# ProtobufInspector
A custom Inspector for Fiddler to deserialize protobuf Requests/Responses and show them as Json in Fiddler

## Installation
Use the Install.bat which gets copied to the output (Debug/Release) folder to copy the relevant dlls to Fiddler's Inspector directory. Launch Fiddler to find a new tab amongst existing Inspectors as "Protobuf"
## Usage
The new "Protobuf" tab gives you the option to select an Assembly/Dll which should contain the class definition of proto, which you intend to visualize as Json. Browse to the Assembly location and load it. This will populate all Classes present in that assembly in the dropdown. Choose the correct ClassName and you should be ready to visualize any protobuf Request/Response in Fiddler.
