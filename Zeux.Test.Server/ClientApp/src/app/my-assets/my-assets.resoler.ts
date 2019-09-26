import { Resolve, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';


@Injectable()
export class AssetResolver implements Resolve<any> {
    type: any;

    constructor(      
        ) {}

    resolve(route: ActivatedRouteSnapshot) {        
       return route.params.type;
    }
}