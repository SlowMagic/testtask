import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyAssetsComponent } from 'src/app/my-assets/my-assets.component';
import { OpportunitiesComponent } from 'src/app/opportunities/opportunities.component';
import { AssetResolver } from './my-assets/my-assets.resoler';

const routes: Routes = [
  {
    path: 'myassets/:type',
    component: MyAssetsComponent,
    resolve: { type: AssetResolver }
  },
  {
    path: 'opportunities',
    component: OpportunitiesComponent
  },
  {
    path: '**',
    redirectTo: 'myassets/all'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
