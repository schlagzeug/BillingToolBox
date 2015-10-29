del merged.sql
del merged.tmp

@Echo Off

SET database=ID1000BDDA7

SET DatabaseInstance=HFDSREYNOLDSW7D\SQLSERVER

sqlcmd -S %DatabaseInstance% -d %database% -Q ""
IF NOT %ERRORLEVEL%==0 GOTO END


rem ECHO Getting latest from TFS Billing/Database/BDD/TableScripts
rem "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE" get "$/Products/DailyBuild/Billing/Database/BDD/TableScripts"
rem 
rem ECHO Getting latest from TFS Billing/Database/BDD/Functions
rem "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE" get "$/Products/DailyBuild/Billing/Database/BDD/Functions"
rem 
rem ECHO Getting latest from TFS Billing/Database/BDD/Views
rem "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE" get "$/Products/DailyBuild/Billing/Database/BDD/Views"
rem 
rem ECHO Getting latest from TFS Billing/Database/BDD/StoredProcs
rem "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE" get "$/Products/DailyBuild/Billing/Database/BDD/StoredProcs"
rem 
rem ECHO Getting latest from TFS Billing/Database/BDD/Indexes
rem "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE" get "C:\Work\Products\DailyBuild\Billing\Database\BDD\Indexes"
rem 
rem ECHO Getting latest from TFS Billing/Database/BDD/DataScripts
rem "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE" get "C:\Work\Products\DailyBuild\Billing\Database\BDD\DataScripts"
rem 
rem ECHO Getting latest from TFS Billing/Database/BDD/RunEveryTime
rem "C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE" get "C:\Work\Products\DailyBuild\Billing\Database\BDD\RunEveryTime"

ECHO Building Merge Script.


echo. >> merged.tmp
echo. >> merged.tmp


for %%I in (C:\Work\Products\DailyBuild\Billing\Database\BDD\TableScripts\*.sql) do (
    @rem echo %%~fI >> merged.tmp
    @rem echo --------- >> merged.tmp
    type %%I >> merged.tmp
    echo. >> merged.tmp
    echo. >> merged.tmp
)

for %%I in (C:\Work\Products\DailyBuild\Billing\Database\BDD\Functions\*.sql) do (
    @rem echo %%~fI >> merged.tmp
    @rem echo --------- >> merged.tmp
    type %%I >> merged.tmp
    echo. >> merged.tmp
    echo. >> merged.tmp
)

for %%I in (C:\Work\Products\DailyBuild\Billing\Database\BDD\Views\*.sql) do (
    @rem echo %%~fI >> merged.tmp
    @rem echo --------- >> merged.tmp
    type %%I >> merged.tmp
    echo. >> merged.tmp
    echo. >> merged.tmp
)
 
for %%I in (C:\Work\Products\DailyBuild\Billing\Database\BDD\StoredProcs\*.sql) do (
    @rem echo %%~fI >> merged.tmp
    @rem echo --------- >> merged.tmp
    type %%I >> merged.tmp
    echo. >> merged.tmp
    echo. >> merged.tmp
)

for %%I in (C:\Work\Products\DailyBuild\Billing\Database\BDD\Indexes\*.sql) do (
    @rem echo %%~fI >> merged.tmp
    @rem echo --------- >> merged.tmp
    type %%I >> merged.tmp
    echo. >> merged.tmp
    echo. >> merged.tmp
)

for %%I in (C:\Work\Products\DailyBuild\Billing\Database\BDD\RunEveryTime\*.sql) do (
    @rem echo %%~fI >> merged.tmp
    @rem echo --------- >> merged.tmp
    type %%I >> merged.tmp
    echo. >> merged.tmp
    echo. >> merged.tmp
)


ren merged.tmp merged.sql


ECHO Processing SQL statements.

sqlcmd -S %DatabaseInstance% -d %Database% -i merged.sql -o MergeOutPut.txt

ECHO SQL Statements Processed

ECHO Checking for Errors

FIND /N "%DatabaseInstance%" MergeOutput.txt

PAUSE
GOTO DONE

:END
ECHO --------------------------------------------------------
ECHO Bad database instance %DatabaseInstance% or database %Database%
PAUSE

:DONE

