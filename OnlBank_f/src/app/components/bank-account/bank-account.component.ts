import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bank-account',
  templateUrl: './bank-account.component.html',
  styleUrl: './bank-account.component.css'
})
export class BankAccountComponent implements OnInit {
  items = [
    {"id":1,"title":"Gan Loadwick","number":320781455803,"date":"6/22/2024"},
    {"id":2,"title":"Luella Rapelli","number":105719892857,"date":"3/8/2024"},
    {"id":3,"title":"Connie McQuorkel","number":403276603294,"date":"11/9/2023"},
    {"id":4,"title":"Elysia Works","number":313118521643,"date":"1/27/2024"},
    {"id":5,"title":"Towney Berceros","number":776002606817,"date":"4/20/2024"},
    {"id":6,"title":"Michael Denniss","number":742321049191,"date":"4/18/2024"},
    { "id": 7, "title": 'Card 1', "number": 320252455803, "date": '2024-06-29' },
    { "id": 8, "title": 'Card 2', "number": 245245262403, "date": '2024-06-28' },
  ];

  colors: string[] = [];

  ngOnInit(): void {
    this.colors = this.items.map(() => this.getRandomColor());
  }

  getRandomColor(): string {
    const letters = '0123456789ABCDEF';
    let color = '#';
    for (let i = 0; i < 6; i++) {
      color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
  }
}
