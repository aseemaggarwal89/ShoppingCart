import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IProduct } from 'src/app/shared/models/product';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  private quantitySource = new BehaviorSubject<number>(1);
  quantity$ = this.quantitySource.asObservable();

  quantityToAdd: number;

  constructor(private shopService: ShopService, private route: ActivatedRoute,
              private bcService: BreadcrumbService,
              private basketService: BasketService)  {
    this.bcService.set('@productDetails', ' ');
  }

  ngOnInit(): void {
    this.loadProduct();
    this.quantityToAdd = 1;
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.product, this.quantityToAdd);
  }
  incrementQuantity() {
    this.quantityToAdd += 1;
  }

  decrementQuantity() {
    if (this.quantityToAdd > 1) {
      this.quantityToAdd -= 1;
    }
  }

  loadProduct() {
    this.shopService.getProduct(this.route.snapshot.params.id).subscribe(product => {
      this.product = product;
      this.bcService.set('@productDetails', product.name);
    }, error => {
      console.log(error);
    });
  }
}
