export class PaginationRequest {
    first: number = 0;
    rows: number = 20;
    sortField: string;
    sortOrder: number = 1

    public static toQuery(request: PaginationRequest) : string {
        return `skip=${request.first}&take=${request.rows}&sortField=${request.sortField || ''}&sortOrder=${request.sortOrder}`;
    }
}

export interface PaginationResult<T> {
    totalCount: number
    data: Array<T>
}