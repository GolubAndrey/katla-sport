import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { ProductToSectionRequestsListItem } from '../models/product-section-request-list-item';


@Injectable({
    providedIn: 'root'
})

export class ProductToSectionRequestsService {
    private url = environment.apiUrl + 'api/productRequests';

    constructor(private http: HttpClient) { }

    getProductToSectionRequests():Observable<Array<ProductToSectionRequestsListItem>> {
        return this.http.get<Array<ProductToSectionRequestsListItem>>(`${this.url}`);
    }

    confirmRequest(requestId: number): Observable<Object> {
        return this.http.put(`${this.url}/${requestId}/confirm`, null);
    }

    rejectRequest(requestId: number): Observable<Object> {
        return this.http.put(`${this.url}/${requestId}/reject`, null);
    }

}
