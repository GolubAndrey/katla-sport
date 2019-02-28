import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { HiveSection } from '../models/hive-section';
import { HiveSectionListItem } from '../models/hive-section-list-item';
import { HiveSectionProductsListItem } from '../models/hive-section-products-list-item';


@Injectable({
    providedIn: 'root'
})

export class HiveSectionProductsService {
    private url = environment.apiUrl + 'api/sectionProducts/';

    constructor(private http: HttpClient) { }

    getSectionProducts(hiveSectionId: number):Observable<Array<HiveSectionProductsListItem>> {
        return this.http.get<Array<HiveSectionProductsListItem>>(`${this.url}${hiveSectionId}`);
    }

}
