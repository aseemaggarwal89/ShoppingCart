import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IPagination } from '../shared/models/pagination';
import { IType } from '../shared/models/productType';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
import { IProduct } from '../shared/models/product';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = environment.apiURL;
  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    const params = shopParams.getHttpParams();
    // tslint:disable-next-line: no-use-before-declare
    return this.http.get<IPagination>(ApiProvider.url(APIType.products), { observe: 'response', params})
    .pipe(map(response => {
       return response.body;
     }));
  }

  getBrands() {
    // tslint:disable-next-line: no-use-before-declare
    return this.http.get<IBrand[]>(ApiProvider.url(APIType.brands));
  }

  getTypes() {
    // tslint:disable-next-line: no-use-before-declare
    return this.http.get<IType[]>(ApiProvider.url(APIType.types));
  }

  getProduct(id: number) {
   // tslint:disable-next-line: no-use-before-declare
   return this.http.get<IProduct>(ApiProvider.url(APIType.products, id));
  }
}

class ApiProvider {
  static baseUrl = environment.apiURL;

  static url(type: APIType, productId?: number) {
    let prefix = '';
    switch (type) {
      // tslint:disable-next-line: no-use-before-declare
      case APIType.brands:
      prefix = 'products/brands/';
      break;
      // tslint:disable-next-line: no-use-before-declare
      case APIType.types:
        prefix = 'products/types/';
        break;
      // tslint:disable-next-line: no-use-before-declare
      case APIType.products:
        prefix = 'products/';
        if (productId) {
          prefix = prefix + productId;
        }

        break;
    }

    return this.baseUrl + prefix;
  }
}

enum APIType {
  brands,
  types,
  products
}
