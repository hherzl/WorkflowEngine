Workflow Engine

----------------------
Projects description:

WorkflowEngine: console application

WorkflowEngine.Designer: web api & ui designer

WorkflowEngine.Designer.Tests web api unit tests

WorkflowEngine.Tests: unit tests

WorkflowEngine.Model: workflow model

WorkflowEngine.UI: wpf application

---------------------------------------------------
Console application command line examples:

WorkflowEngine /d:enterprise /u:jhon /p:123 /sf:C:\Temp\Workflows\RegisterCustomer.xml

WorkflowEngine /d:enterprise /u:jhon /p:123 /sf:C:\Temp\Workflows

WorkflowEngine /d:enterprise /u:jhon /p:123 /sf:C:\Temp\Workflows /od:C:\Temp\Results

WorkflowEngine /ui

WorkflowEngine /ui /d:Acme /u:Admin /p:12345

------------------------------
Command line arguments:

/ui: UI
/d: Domain
/u: User
/p: Password
/sd: SourceDirectory
/sf: SourceFile
/od: OutputDirectory
/of: OutputFile
/off: OutputFileFormat
