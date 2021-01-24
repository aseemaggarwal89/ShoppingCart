import { environment } from 'src/environments/environment';

export class ApiProvider {
    static baseUrl = environment.apiURL;

    static url(type: APIType, Id?: any) {
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
          if (Id) {
            prefix = prefix + Id;
          }
          break;
        // tslint:disable-next-line: no-use-before-declare
        case APIType.basket:
          prefix = 'basket/';
      }

      return this.baseUrl + prefix;
    }
  }

export enum APIType {
    brands,
    types,
    products,
    basket
  }
