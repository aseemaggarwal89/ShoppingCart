import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { ApiProvider, APIType } from '../shared/Utilitiy/ApiProvider';
import { IPagination } from '../shared/models/pagination';
import { IType } from '../shared/models/productType';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
import { IProduct } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    const params = shopParams.getHttpParams();
    // tslint:disable-next-line: no-use-before-declare
    const url = ApiProvider.url(APIType.products);

    return this.http.get<IPagination>(url, { observe: 'response', params})
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
