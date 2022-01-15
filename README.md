### Tutorial: about how to use Obfuscar Obfuscate your important C# code .even published as a single file

#### 0.create a solution

```
# create a class library project. then create a console application and reference the class library
```

#### 1.install obfuscar
```shell
Install-Package Obfuscar -Version 2.2.32

# or

dotnet add package Obfuscar --version 2.2.32
```

#### 2.write `obfuscar.xml` and set `always copy`
```xml
<?xml version="1.0" encoding="utf-8" ?>
<Obfuscator>
	<Var name="InPath" value="." />
	<Var name="OutPath" value="./Obfuscator" />
	<Module file="$(InPath)/Lib.dll" />
</Obfuscator>
```

#### 3.specify build events
```shell
cd $(TargetDir)
"$(Obfuscar)" obfuscar.xml
xcopy Obfuscator\*.dll   /y /e /i /q
```
#### 4.build or publish your project
