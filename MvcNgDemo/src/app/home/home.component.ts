import { Component, OnInit } from '@angular/core';
import { Http, Response } from '@angular/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

    data: object;
    loading: boolean;

    constructor(private http: Http) { }

    ngOnInit() {
    }

    makeRequest() {
        this.loading = false;

        this.http.request('/api/Customers/GetCustomers')
            .subscribe((res: Response) => {
                this.data = res.json();
                this.loading = false;
            });
    }
}
