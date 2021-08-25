# PIN-Seminar
 
#Aplikacija za udomljavanje životinja

##Login i registracija 
Koristi se ASP.NET CORE MVC Framework koji sadži svoj Identity preko kojeg se korisnik logira i registrira te sprema u bazu.
Lozinka se hashira samo u jednom smjeru radi sigurnosti.

##Menu Ljubimci
 U Menu Ljubimci moguće je ući samo kao logirani korisnik, ako pokušamo ući bez da smo se logirali izbacit će nam Login page tako da smo prisiljeni logirati se.
 Menu Ljubimci je zamišljen kao popis ljubimaca za udomljavanje u kojem se dodaje ime ljubimca,vrstu te datum rodenja.
 Tablica u kojoj mogu samo logirani korisnici dodavati/brisati/mijenjati podatke o životinji.
 Tablica Ljubimci može se pretraživati samo po imenu Ljubimca. 