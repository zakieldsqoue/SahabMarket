



  //  var ItemsApp = angular.module("myApp", ['ngRoute']);

angular.module('ItemsApp', ['dx'])
    .controller('ItemsCtrl', function ($scope, $http) {
        $http.get(API.APIURL + "Categories")
            .then(function (Categories) {
                $http.get(API.APIURL + "Item")
                    .then(function (Items) {

                        $scope.dataGridOptions = {
                            dataSource: Items.data,
                            allowColumnReordering: true,
                            bindingOptions: {
                                grouping: "grouping"
                            },
                            allowColumnResizing: true,
                            showRowLines: true,
                            showBorders: true,
                            paging: {
                                pageSize: 10
                            },
                            columnChooser: {
                                enabled: true,
                                height: 180,
                                width: 400,
                                allowSearch: true,
                                emptyPanelText: 'A place to hide the columns'
                            },
                            groupPanel: {
                                visible: true,
                                allowColumnDragging: true
                            },
                            searchPanel: {
                                visible: true,
                                width: 250
                            },
                          
                            columns: [{
                                dataField: "ItemImage",
                                width: 100,
                                allowFiltering: false,
                                allowSorting: false,
                                cellTemplate: "cellTemplate"
                            }, {
                                dataField: "ItemName",
                                caption: "Name"
                              
                            },
                                "Price",
                                "IsAvailable",
                                "Quantity", {
                                dataField: "CatID",
                                caption: "Categories",
                                lookup: {
                                    dataSource: Categories.data,
                                    valueExpr: "CatID",
                                    displayExpr: "CatName"
                                }
                            }, "Discount",
                                "SalePrice"
                            ]
                        };
                       

                    });
            });
    });
        








    //var indexController = function ($scope) {
    //         $.get(API.APIURL + "Items", function (Items) {


    //        $scope.dataGridOptions = {
    //            dataSource: Items,
    //            columns: [{
    //                dataField: "Picture",
    //                width: 100,
    //                allowFiltering: false,
    //                allowSorting: false,
    //                cellTemplate: "cellTemplate"
    //            }, {
    //                dataField: "ItemName",
    //                caption: "Name",
    //                width: 70
    //            },
    //                "Price",
    //                "IsAvailable",
    //                "Quantity", {
    //                    dataField: "CatID",
    //                    caption: "Categories",
    //                    lookup: {
    //                        dataSource: DevExpress.data.AspNet.createStore({
    //                            key: "CatID",
    //                            loadUrl: API.APIURL + "Categories",
    //                            onBeforeSend: function (method, ajaxOptions) {
    //                                ajaxOptions.xhrFields = { withCredentials: true };
    //                            }
    //                        }),
    //                        valueExpr: "CatID",
    //                        displayExpr: "CatName"
    //                    }
    //                }, "Discount",
    //                "SalePrice"
    //            ]
    //        };

    //    });
    //}
    //ItemsApp.controller('mycont', function ($scope) {

   
    //});
       
