import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpService } from 'src/app/http/http.service';
import {AssetViewModel, AssetType } from 'src/app/models/asset.model';

@Injectable()
export class AssetService {

    constructor(private http: HttpService) {
    }

    public getAssets(): Observable<Array<AssetViewModel>> {
      const url = '/api/asset/products';
      return this.http.get(url).pipe(
        map((assets: AssetViewModel[]) => this.firstLetterToUppercase(assets)));
    }

    public getAssetsType(): Observable<Array<AssetType>> {
        const url = '/api/asset/GetTypes';
        return this.http.get(url);
    }

    private firstLetterToUppercase(assets: Array<AssetViewModel>):  Array<AssetViewModel> {
        assets.forEach( asset => asset.name = asset.name.charAt(0).toUpperCase() + asset.name.slice(1)); 
        return  assets;
    }
}
