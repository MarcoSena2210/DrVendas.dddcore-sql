function ListagemConsulta(table, url, colunas) {
    LigaAguarde();
    $('#' + table).dataTable().fnDestroy();
    $.ajax({
        url: url,
        type: "post",
        dataType: 'json',
        success: function (data) {
            oTable = $("#" + table).dataTable({
                dom: 'Blfrtip',
                buttons: [
                    'excel', 'pdf', 'print'
                ],

                "fnDrawCallback": function (settings) {
                    DesligaAguarde();
                },

                "bAutoWidth": true,
                "destroy": true,
                "stateSave": true,
                "Info": false,
                "bPaginate": true,
                "bLengthChange": true,
                "pageLength": 5,
                "lengthMenu": [02, 05, 10, 20, 30, 40, 50, 70, 80, 90, 100],
                "oLanguage": {
                    "decimal": ",",
                    "thousands": ".",
                    "sProcessing": "Aguarde o Processamento...",
                    "sLengthMenu": "Por Página _MENU_",
                    "sInfo": "",
                    "sZeroRecords": "Não foram encontrados resultados",
                    "sInfoEmpty": "",
                    "sInfoFilterede": "(Filtrado de _MAX_ registros no total",
                    "sInfoFiltered": "",
                    "sInfoPosFix": "",
                    "sSearch": "Buscar",
                    "sUrl": "",
                    "oPaginate": {
                        "sFirst": "Primeiro",
                        "sPrevious": "Anterior",
                        "sNext": "Próximo",
                        "sLast": "Último"
                    },
                },
                data: data,
                columns: colunas
            });
        },
        error: function (data) {

        }
    });

    jQuery.extend(jQuery.fn.dataTableExt.oSort, {
        "currency-pre": function (a) {
            a = replaceall(a, ".", "");
            a = (a === "-") ? 0 : a.replace(/[^\d\-\.]/g, "");
            return parseFloat(a);
        },

        "currency-asc": function (a, b) {
            return a - b;
        },

        "currency-desc": function (a, b) {
            return b - a;

        },

        "date-uk-pre": function (a) {
            var ukDatea = a.split('/');
            return (ukDatea[2] + ukDatea[1] + ukDatea[0]) * 1;
        },

        "date-uk-asc": function (a, b) {
            return ((a < b) ? -1 : ((a > b) ? 1 : 0));
        },

        "date-uk-desc": function (a, b) {
            return ((a < b) ? 1 : ((a > b) ? -1 : 0));
        }

    });
}

function replaceall(str, replace, with_this) {
    var str_hasil = "";
    var temp;
    if (str != undefined) {
        for (var i = 0; i < str.length; i++) // not need to be equal. it causes the last change: undefined..
        {
            if (str[i] == replace) {
                temp = with_this;
            }
            else {
                temp = str[i];
            }
            str_hasil += temp;
        }
    }
    return str_hasil;
}

function LigaAguarde() {
    $("#aguarde").modal('show');
}

function DesligaAguarde() {
    $("#aguarde").modal('hide');
}
