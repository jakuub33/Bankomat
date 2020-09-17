# Bankomat

Aplikacja symulująca działanie bankomatu.
Bankomat zawiera pojemnki banknotów na nominały 10, 20, 50, 100, 200 zł.
Bankomat posiada dwa tryby: użytkownika i serwisowy.

W trybie użytkownika bankomat posiada następujące stany:

• Gotowy do działania (wszystkie pojemniki posiadają banknoty)

• Działający (nie wszystkie nominały są dostępne)

• Pusty (brak banknotów)

W tym trybie użytkownik może wypłacić pieniądze.
 
W trybie serwisowym bankomat posiada następujące stany:

• Pusty (brak banknotów)

• Gotowy do działania

W tym trybie użytkownik może ustalić ilość banknotów w poszczególnych pojemnikach.

Algorytm działania:

Bankomat stara się równomiernie opróżniać pojemniki, aby nie zagłodzić pojemników, ponieważ bankomat, któy zbyt szybko przechodzi ze stanu gotowy do stanu ziałający to słabe rozwiązanie.

Program informuje użytkownika, że jego kwota nie może zostać zrealizowana tylko wtedy kiedy nie może uzbierać z pojemników odpowiednich nominałów. 
Kiedy kwota przekracza całość gotówki w bankomanie program informuje użytkownika o braku takiej ilości gotówki.

Algorytmicznie problem jest wariacją na na temat problemu "siedmiu głodnych filozofów".

![alt text](https://github.com/jakuub33/Bankomat/blob/master/Bankomat/screen.jpg)
