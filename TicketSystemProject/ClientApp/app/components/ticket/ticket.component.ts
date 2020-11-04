import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'ticket',
    templateUrl: './ticket.component.html',
    styleUrls: ['./ticket.component.css']
})
export class TicketComponent {
    public ticketStatuses: TicketStatus[];

    // See home.component
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/ticketstatuses/values').subscribe(result => {
            this.ticketStatuses = result.json() as TicketStatus[];
        }, error => console.error(error));
    }
}

interface TicketStatus {
    id: number;
    name: string;
}
