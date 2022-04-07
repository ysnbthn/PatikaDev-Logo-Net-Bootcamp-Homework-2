# PatikaDev-Logo-Net-Bootcamp-Homework-2

* Middleware yazılacak. İçeriği App version control (bu middleware option parametresi alacak parametre olarakta appsetting.json gelen app-version section değeri alacak)
*  request login ve register ise bir sonraki pipeline'a geçsin (bu requestler dahil değildir altaki işlemler kontrol edilmeyecek)
*  request header da app-version key olacak, request header da gönderdiğim app-version değeri appsetting.json tuttuğum app-version  değerinden büyükse response 401 status kod olacak
* Swagger headerına app-version default key eklenecek. (IOperationFilter interface kullanılarak)
* Swagger 4 endpoint oluşturulacak istediğiniz gibi olabilir. Sadece bir tanesi gösterilmeyecek.
* Microsoft version classı ile version karşılaştırması yapabilirsiniz.

* Middleware ve IOC hakkında 2 dakikalık okunacak, ingilizcesi iyi olanlar ingilizce yazacaklar, yetersiz olanlar ise türkçe makale yayımlayacaklar. Linkedin ve Medium yayınlanacak. Yayınlamadan önce telegram grubunda paylaşın ve birbirinize geri dönüş yapınız.

## Yapılanlar

* HomeController içinde Login, Register, Home ve Hidden endpointleri yapıldı
* Login veya Register endpointlerine istek atıldığında request headerdan gelen app-verison ile appsettingsdeki app-versionu Version sınıfı kullanarak karşılaştıracak middleware yapıldı.
* IOperationFilter kullnarak Swagger içine içinde default parameter olan app-version alanı eklendi.
* IDocumentFilter kullanarak içinde "/hidden" geçen endpointi swagger dökümantasyonunda gizleyecek filter yazıldı.
* [Middleware](https://medium.com/@yasinbatuhanozyurek/what-is-middleware-definition-and-asp-net-core-6-example-4d50ec99387f) ve [IOC](https://medium.com/@yasinbatuhanozyurek/what-is-inversion-of-control-ioc-54c987afc56c) hakkında 2 tane makale yazıldı. 
