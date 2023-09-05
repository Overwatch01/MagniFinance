export function filterUniqueArray(a: any) {
    return [...new Set(a.map((o: any) => JSON.stringify(o)))].map((s: any) => JSON.parse(s));
  }
  
//   export function orderBy(array: any, field:string) {
//     return array.sort((a, b) => a[field] > b[field] ? 1 : -1);
//   }
  
  export function isEmpty(obj: object): boolean {
    if (!obj) {
      return true;
    }
  
    const fields = Object.entries(obj);
    return fields.length == 0;
  }
  
  export function toQuery(obj: object): string {
    if (isEmpty(obj)) {
      return '';
    }
  
    const fields = Object.entries(obj);
    return fields.map(x => `${x[0]}=${x[1]}`).reduce((x,y) => `${x}&${y}`);
  }
  
  export function toDate(value: Date | string): Date | null {
    if (!value) {
      return null;
    }
  
    if (value instanceof Date) {
      return value;
    }
  
    return new Date(value);
    
  }
  
  export function toUTCDate(value: Date | string): Date | null {
      if (!value) {
        return null;
      }
    
      if (value instanceof Date) {
          return new Date(value.toUTCString().slice(0, -4));
      }
    
      const dt = new Date(value);
      const utcDate = new Date(dt.toUTCString().slice(0, -4));
      return utcDate;
    }