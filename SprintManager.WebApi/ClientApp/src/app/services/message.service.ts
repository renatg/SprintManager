import { Injectable } from '@angular/core';
import { MessageService as MS } from "primeng/api";

@Injectable({
    providedIn: 'root'
})
export class MessageService {

    constructor(private messageService: MS) { }

    showError(error: string) {
        this.messageService.add( {severity:'error', summary: error} );
    }

    showInfo(message: string) {
        this.messageService.add({severity:'info', summary: message});
    }

    showSuccess(message: string ){
        this.messageService.add({severity:'success', summary: message});
    }
}
