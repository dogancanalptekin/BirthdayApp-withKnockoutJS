﻿var model =
{
    view: ko.observable("welcome"),
    davetiyeModel:
    {
        Ad: ko.observable(""),
        Eposta: ko.observable(""),
        KatilmaDurumu: ko.observable("true")
    },
    Katilanlar: ko.observableArray([])
}

var formuGoster = function () {
    model.view("form");
}

var formuGonder = function () {
    $.ajax("/api/Davetiye/Ekle",
        {
            type: "POST",
            data: {
                Ad: model.davetiyeModel.Ad,
                Eposta: model.davetiyeModel.Eposta,
                KatilmaDurumu: model.davetiyeModel.KatilmaDurumu
            },
            success: function() {
                katilanlariGetir();
            }
        });
}

var katilanlariGetir = function() {
    $.ajax("/api/DavetiyeGetKatilanlar",
        {
            type: "GET",
            success: function(data) {
                model.Katilanlar.removeAll();
                model.Katilanlar.push.apply(model.Katilanlar,
                    data.map(function(item) {
                        return item.Ad;
                    }));
                model.view("thanks");
            }
        });
}

$(document).ready(function() {
    ko.applyBindings();
});