import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {
    public tickets: Ticket[];

    // Copy-pasted from original template. Did not work all the time, error probably in json but not exactly sure where. No skill to edit and thus fix. :(
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/ticket/values').subscribe(result => {
            this.tickets = result.json() as Ticket[];
        }, error => console.error(error));
    }
    // Here should be other REST functions but I don't have enough TypeScript knowledge to write them in this timeframe.
}

interface Ticket {
    id: number;
    dateFormatted: string;
    details: string;
    status: string;
}
