![v4d_a01_crop](https://user-images.githubusercontent.com/1014562/40412085-9c6e950e-5e72-11e8-9ce5-a279fefd3596.jpg "V4D Logo")

# V4D4Rhino
Rhino3d plugin to access [V4Design](https://v4design.eu/) Repository Assets

![flag_white_high_ec](https://user-images.githubusercontent.com/1014562/40412232-fcbcda74-5e72-11e8-8857-47f7206d7949.jpg)

This project has received funding from the European Union’s Horizon 2020 research and innovation programme under grant agreement No 779962

[![Build status](https://ci.appveyor.com/api/projects/status/nr9r3j4dcl8o7f1g?svg=true)](https://ci.appveyor.com/project/fraguada/v4d4rhino)

# Development

This project is developed on Windows 10, Visual Studio 2017 and is composed of two projects:

- V4D4RhinoPlugin: The Rhino plugin, written in csharp and utilising RhinoCommon, CefSharp, and Newtonsoft.Json
- V4DRhinoViewer: A Vue.js (cli-3) project for building the UI for the V4D4RhinoPlugin. Uses Vuetify.js for UI components.

Follow these steps when starting to develop:

1. Clone or fork this repo
2. From the `v4d4rhinoviewer` directory, run `npm install`
3. From the `v4d4rhinoviewer` directory, run `npm run serve`
4. Open the `V4D4Rhino.sln` in Visual Studio 2017
5. Restore NuGet Packages
6. Start Visual Studio debugging. Rhino will be launched.

Follow these steps after pulling new source:

1. From the `v4d4rhinoviewer` directory, run `npm install`
2. From the `v4d4rhinoviewer` directory, run `npm run serve`
3. Open the `V4D4Rhino.sln` in Visual Studio 2017
4. Start Visual Studio debugging. Rhino will be launched.

To contribute, commit changes to a development branch and open a pull request.

# Releases

TODO
