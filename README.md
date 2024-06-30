## Nasıl Kullanılır?

`Exchange` sınıfı oluşturulur.

```csharp
Exchange exchange = new();
```

Kur bilgisi alamak için `GetAsync` fonksiyonunu kullanabiliriz.

`GetAsync` fonksiyonu 2 adet parametre almaktadır. 
- Kur Kodu
- Kur Tarihi (**Opsiyonel**. Eğer verilmezse en güncel kur bilgisini alır)

```csharp
ExchangeRate kurBilgisi = await exchange.GetAsync(ExchangeTypes.CurrencyCode.USD);
```

Çıktısı bu şekilde olacaktır:
```json
{
  "currency": "US DOLLAR",
  "currencyTr": "ABD DOLARI",
  "currencyCode": "USD",
  "exRateDateTime": "28.06.2024",
  "exRateDateTimeDefault": "2024-06-28T00:00:00",
  "unit": 1,
  "forexBuying": 32.8262,
  "forexSelling": 32.8853,
  "banknoteBuying": 32.8032,
  "banknoteSelling": 32.9347
}
```

---

Tarih bazlı kur bilgisi almak için ise şu şekilde kullanılabilir:
```csharp
ExchangeRate kurBilgisi = await exchange.GetAsync(ExchangeTypes.CurrencyCode.USD, DateTime.Parse("2024-06-10"));
```

Çıktısı şu şekilde olacaktır:
```json
{
  "currency": "US DOLLAR",
  "currencyTr": "ABD DOLARI",
  "currencyCode": "USD",
  "exRateDateTime": "10.06.2024",
  "exRateDateTimeDefault": "2024-06-10T00:00:00",
  "unit": 1,
  "forexBuying": 32.3699,
  "forexSelling": 32.4282,
  "banknoteBuying": 32.3472,
  "banknoteSelling": 32.4769
}
```

---

Çapraz kurları almak için şu şekilde kullanabiliriz:
```csharp
ExchangeRateCross kurBilgisi = await exchange.GetCrossAsync(ExchangeTypes.CurrencyCode.JPY);
```

Çıktısı şu şekilde olacaktır:
```json
{
  "currency": "JAPENESE YEN",
  "currencyTr": "JAPON YENİ",
  "currencyCode": "JPY",
  "exRateDateTime": "28.06.2024",
  "exRateDateTimeDefault": "2024-06-28T00:00:00",
  "unit": 100,
  "crossRate": 160.76,
  "crossCurrency": "US DOLLAR",
  "crossCurrencyTr": "ABD DOLARI"
}
```

---

Tarih bazlı çapaz kur bilgisi almak için ise şu şekilde kullanılabilir:

```csharp
ExchangeRateCross kurBilgisi = await exchange.GetCrossAsync(ExchangeTypes.CurrencyCode.JPY, DateTime.Parse("2024-06-10"));
```

Çıktısı şu şekilde olacaktır:
```json
{
  "currency": "JAPENESE YEN",
  "currencyTr": "JAPON YENİ",
  "currencyCode": "JPY",
  "exRateDateTime": "10.06.2024",
  "exRateDateTimeDefault": "2024-06-10T00:00:00",
  "unit": 100,
  "crossRate": 156.95,
  "crossCurrency": "US DOLLAR",
  "crossCurrencyTr": "ABD DOLARI"
}
```
