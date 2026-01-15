# CI_CD_Group_8 – Personnummerkontroll (C#)

## Vad gör appen?
Konsolapplikation som validerar svenskt personnummer genom:
1) Formatkontroll (10/12 siffror, med/utan - eller +)
2) Datumkontroll (YYMMDD -> giltigt datum)
3) Luhn-kontroll (kontrollsiffra)

## Kör lokalt
```bash
dotnet run --project CI_CD_Group_8 -- 900101-0017
