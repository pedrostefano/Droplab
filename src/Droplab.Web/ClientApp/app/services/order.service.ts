import { Injectable } from '@angular/core';
import { Http } from '@angular/http'; 
import 'rxjs/add/operator/map';


@Injectable()
export class OrderService {
  private readonly orderEndpoint = 'api/order/';

  constructor(private http: Http) { }

  getOrders() {
  }


}