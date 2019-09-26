import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AssetViewModel, AssetType } from 'src/app/models/asset.model';
import { AssetService } from 'src/app/services/asset.service';

@Component({
  selector: 'app-my-assets',
  templateUrl: './my-assets.component.html',
  styleUrls: ['./my-assets.component.scss']
})
export class MyAssetsComponent implements OnInit {

  private type: string;
  public assetTypes: Array<AssetType>;
  public assets: Array<AssetViewModel>;
  public filteredAssets: Array<AssetViewModel>;

  constructor(private route: ActivatedRoute,
    private assetService: AssetService) { }   

  ngOnInit() {  
    this.assetService.getAssets().subscribe(result => { this.assets = result; });
    this.assetService.getAssetsType().subscribe(result => { this.assetTypes = result; });
    this.type  = this.route.snapshot.data.type;

    this.route.params.subscribe(() => {
      this.type  = this.route.snapshot.data.type;
    });
  }

  filterAssets():  Array<AssetViewModel> {
    if (this.assets && this.type) {
        switch (this.type) {
          case 'all' : {
            return this.assets;
          }
          default: {
            return this.assets.filter(asset => asset.typeName.toLowerCase() === this.type.toLowerCase());
          }
      }
    } else {
     return  Array<AssetViewModel>();
    }
  }
}



