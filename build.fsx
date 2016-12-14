
// Build and publish the build scripts and related tools

#r @"./packages/ci/FAKE/tools/FakeLib.dll"

open Fake

let solutionFile = "GoTray.sln"
let projectFiles = "src/**/*.??proj"

let buildDir = "build"
let buildConfiguration = "Debug"

Target "Clean" (fun _ ->
    CleanDir buildDir
)

Target "Prepare" (fun _ ->
    ()
)

Target "AssemblyInfos" (fun _ ->
    ()
)

Target "Build" (fun _ ->
    solutionFile
    |> Fake.MSBuildHelper.build (fun p ->
        {p with 
            Targets = ["Rebuild"]
            Verbosity = Some(Minimal)
            Properties = ["Configuration", buildConfiguration]
        })
)

Target "Test" (fun _ ->
    ()
)

Target "Pack" (fun _ ->
    ()
)

Target "PublishDevelopment" (fun _ ->
    ()
)

Target "Integrate" DoNothing


"Clean"
    ==> "Prepare"

"AssemblyInfos"
    ==> "Prepare"

"Prepare"
    ==> "Build"

"Build"
    ==> "Test"

"Test"
    ==> "Pack"

"Pack"
   ==> "PublishDevelopment"

"PublishDevelopment"
    ==> "Integrate"

RunTargetOrDefault "Test"


