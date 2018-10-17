import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-customer-data',
  templateUrl: './customer-data.component.html',
  styleUrls: ['./customer-data.component.css']
})
export class CustomerDataComponent implements OnInit {
    @Input() customer: any;

    constructor() { }

    ngOnInit() {
    }

}
