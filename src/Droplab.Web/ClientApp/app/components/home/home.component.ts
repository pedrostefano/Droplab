import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../services/order.service';
import {DataSource} from '@angular/cdk/collections';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/observable/of';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    
    ngOnInit() {
        
    }
        
}
