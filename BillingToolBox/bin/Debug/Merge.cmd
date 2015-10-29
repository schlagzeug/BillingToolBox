del merged.sql
del merged.tmp

@Echo Off

SET database=<DATABASE>

SET DatabaseInstance=<SERVER>

sqlcmd -S %DatabaseInstance% -d %database% -Q ""
IF NOT %ERRORLEVEL%==0 GOTO END


ECHO Getting latest from TFS Billing/Database/BDD/TableScripts
"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE" get "$/Products/DailyBuild/Billing/Database/BDD/TableScripts"

ECHO Getting latest from TFS Billing/Database/BDD/Functions
"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE" get "$/Products/DailyBuild/Billing/Database/BDD/Functions"

ECHO Getting latest from TFS Billing/Database/BDD/Views
"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE" get "$/Products/DailyBuild/Billing/Database/BDD/Views"

ECHO Getting latest from TFS Billing/Database/BDD/StoredProcs
"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE" get "$/Products/DailyBuild/Billing/Database/BDD/StoredProcs"

ECHO Getting latest from TFS Billing/Database/BDD/Indexes
"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE" get "C:\Work\Products\DailyBuild\Billing\Database\BDD\Indexes"

ECHO Getting latest from TFS Billing/Database/BDD/DataScripts
"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE" get "C:\Work\Products\DailyBuild\Billing\Database\BDD\DataScripts"

ECHO Getting latest from TFS Billing/Database/BDD/RunEveryTime
"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\TF.EXE" get "C:\Work\Products\DailyBuild\Billing\Database\BDD\RunEveryTime"

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
