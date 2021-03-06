import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Relation } from 'src/app/shared/relation';
import { HttpClient} from '@angular/common/http';
import { URLs } from 'src/app/shared/URLs';
import { DeleteRelation } from 'src/app/shared/relation-delete';
import { ICreateRelation } from 'src/app/shared/relation-create';

@Injectable({
  providedIn: 'root'
})
export class RelationService {

  constructor(private httpClient: HttpClient) { }

  public getRelations(category: string, sortedProperty: string, descending: boolean): Observable<Relation[]> {
    if (category === null) {
      return this.httpClient.get<Relation[]>(URLs.BaseUrl + 'relations/?propertyForSorting=' + sortedProperty + '&descending=' + descending);
    }
    else {
      return this.httpClient.get<Relation[]>(URLs.BaseUrl + 'relations/?categoryId=' + category + '&propertyForSorting=' + sortedProperty + '&descending=' + descending);
    }
  }

  public getRelation(relationId: string): Observable<Relation> {
    return this.httpClient.get<Relation>(URLs.BaseUrl + 'relations/' + relationId);
  }

  public createRelation(relation: ICreateRelation): Observable<Relation> {
    return this.httpClient.post<Relation>(URLs.BaseUrl + 'relations/create', relation);
  }

  public editRelation(relationId: string, relation: ICreateRelation): Observable<Relation> {
    return this.httpClient.put<Relation>(URLs.BaseUrl + 'relations/update/' + relationId, relation);
  }

  public deleteRelations(relationArray: DeleteRelation[]): Observable<any> {
    return this.httpClient.put<any>(URLs.BaseUrl + 'relations/delete', relationArray);
  }
}
