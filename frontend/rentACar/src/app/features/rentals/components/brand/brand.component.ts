import { Component, OnInit } from '@angular/core';
import { ListResponseModel } from 'src/app/core/models/listReponseModel';
import { BrandListModel } from '../../models/brandListModel';
import { BrandService } from '../../services/brand.service';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css']
})
export class BrandComponent implements OnInit {

  brands:ListResponseModel<BrandListModel> = {items:[]}
  selectedBrand:BrandListModel
  constructor(private brandService:BrandService) { }

  ngOnInit(): void {
    this.getBrands();
  }

  getBrands(){
    this.brandService.getBrands(0,100).subscribe(data=>{
      this.brands = data
    })
  }

}
