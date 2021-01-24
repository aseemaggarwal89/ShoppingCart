import { HttpParams } from '@angular/common/http';

export class BasketParams {
    constructor(private basketId: string) {
    }

    getHttpParams() {
        let params = new HttpParams();
        if (this.basketId) {
            params = params.append('id', this.basketId);
          }

        return params;
    }
}
