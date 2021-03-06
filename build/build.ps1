properties{
	$workingDir = $path.Path
	
	$nunit = Join-path $workingDir "src\packages\NUnit.Runners.2.6.3\tools\nunit-console.exe"
	
	$sln = join-path $workingDir "src\Journey.sln"
	$testDll = join-path $workingDir "src\Tests\bin\Debug\Journey.Tests.dll"
	
}

cd ..
$path = Get-Location
task default -depends build.commit

task build.commit -depends build.compile, build.unittest

task build.compile{
	Exec { msbuild $sln /t:Clean /p:Configuration=Debug /v:quiet } 
	Exec { msbuild $sln /t:Build /p:Configuration=Debug  /v:normal } 
}

task build.unittest{
Exec { & $nunit $testDll  /framework:net-4.5 /nologo /nodots /xml=TestResult.xml }
}
