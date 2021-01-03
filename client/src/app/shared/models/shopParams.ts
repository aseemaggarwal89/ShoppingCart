import { HttpParams } from '@angular/common/http';

export class ShopParams {
    brandId = 0;
    typeId = 0;
    sort = 'name';
    pageNumber = 1;
    pageSize = 6;
    search: string;

    getHttpParams() {
        let params = new HttpParams();
        if (this.brandId !== 0) {
            params = params.append('brandId', this.brandId.toString());
          }

        if (this.typeId !== 0) {
            params = params.append('typeId', this.typeId.toString());
          }

        if (this.sort) {
            params = params.append('sort', this.sort);
          }

        if (this.pageNumber) {
            params = params.append('pageIndex', this.pageNumber.toString());
          }

        if (this.search) {
            params = params.append('search', this.search);
          }

        return params;
    }
}
