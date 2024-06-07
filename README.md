# Zahtevi

## Dozivljajni
- Dva zasebna grid-a koji reprezentuju table igraca.
- Top bar koji sadrzi opcije za novu igru.
- Graficki prikaz koliko preostalih brodova protivnik ima.
- Pustanje zvukova na:
    - Pogodak
    - Promasaj
    - Potapanje
    - Pobedu

Na kraju igre, ponuditi novu partiju ili izlazak. 
## Logicki
- Odabir velicine igre. To se vrsi pred pocetak, koristeci neku formu.
- Kreira se instanca igre
- Igraci upisuju svoja imena
- Pocinje faza postavljanja brodova, prvo jedan pa drugi igrac.
- Brodovi se postavljaju tako sto se klikcu polja koja ce ga predstavljati, uz validaciju.
- Na kraju igre, upisuje se rezultat igre u neki txt fajl.
- Koriscenjem gornjeg menija se moze videti istorija igara.

## Uputstvo
- napraviti prazan folder (najlakse na particiji D:)
- preko powershell-a pristupiti folderu (cd komanda)
- sa github-a kopirati url za kloniranje
- komanda git clone url
- po zavrsetku rada komanda git add .
- git commit -m "Ukratko sta je promenjeno"
- git push

Ukoliko dodje do greske permission denied, iz Credential Managera izbrisati sve vezano za git
