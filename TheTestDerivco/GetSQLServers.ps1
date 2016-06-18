Function Get-SqlInstances {
  Param($ServerName = '.')
  Param(&cred = &AdminUser | &AdminPassword)	

  $localInstances = @()
  [array]$captions = gwmi win32_service -computerName $ServerName -ScriptBlock {$env:USERNAME} -Credential &cred | ?{$_.Name -match "mssql*" -and $_.PathName -match "sqlservr.exe"} | %{$_.Caption}
  foreach ($caption in $captions) {
    if ($caption -eq "MSSQLSERVER") {
      $localInstances += "MSSQLSERVER"
    } else {
      $temp = $caption | %{$_.split(" ")[-1]} | %{$_.trimStart("(")} | %{$_.trimEnd(")")}
      $localInstances += "$ServerName\$temp"
    }
  }
  $localInstances
}