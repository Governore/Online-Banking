import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-home-section',
  templateUrl: './home-section.component.html',
  styleUrl: './home-section.component.css'
})

export class HomeSectionComponent{

  public data= [{"id":1,"username":"msofe0","accname":"Minnnie Sofe","amount":45976017.818,"trantype":"Teal","date":"12/19/2023"},
    {"id":2,"username":"easplen1","accname":"Earle Asplen","amount":7044654.099,"trantype":"Pink","date":"1/9/2024"},
    {"id":3,"username":"gcuseck2","accname":"Gayler Cuseck","amount":75487521.559,"trantype":"Indigo","date":"9/25/2023"},
    {"id":4,"username":"mfawltey3","accname":"Michel Fawltey","amount":21722135.824,"trantype":"Mauv","date":"10/17/2023"},
    {"id":5,"username":"tpariss4","accname":"Theo Pariss","amount":8978481.719,"trantype":"Red","date":"4/13/2024"},
    {"id":6,"username":"lpirdue5","accname":"Lynn Pirdue","amount":52550861.374,"trantype":"Khaki","date":"11/24/2023"},
    {"id":7,"username":"imargery6","accname":"Issiah Margery","amount":4720739.783,"trantype":"Yellow","date":"3/15/2024"},
    {"id":8,"username":"bsetchfield7","accname":"Binnie Setchfield","amount":32023126.445,"trantype":"Blue","date":"2/12/2024"},
    {"id":9,"username":"drolfe8","accname":"Dewey Rolfe","amount":74357001.786,"trantype":"Teal","date":"1/23/2024"},
    {"id":10,"username":"dkelsow9","accname":"Dorey Kelsow","amount":37563897.022,"trantype":"Goldenrod","date":"8/24/2023"}]



}
