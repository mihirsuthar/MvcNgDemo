import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http, Response } from '@angular/http';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
    data: object;
    id: string;

    constructor(private route: ActivatedRoute, private http: Http) {
        this.route.params.subscribe(params => {
            this.id = params['id'];
        });

        this.http.request('/api/Customers/GetCustomer/' + this.id)
            .subscribe((res: Response) => {
                this.data = res.json();
            });
    }

    ngOnInit() {
        
    }

}
