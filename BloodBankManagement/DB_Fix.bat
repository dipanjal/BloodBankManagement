@echo off
taskkill -f -im BloodBankManagement.exe
cls
copy "bin\Debug\BloodBankDB.mdf" "BloodBankDB.mdf"
copy "bin\Debug\BloodBankDB_log.ldf" "BloodBankDB_log.ldf"
ping 127.0.0.1 -n 3 > nul
exit
