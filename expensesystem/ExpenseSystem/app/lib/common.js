
function CreateDefaultNewEvent() {

    localStorage.setItem('tournId', null);
    localStorage.setItem('name', null);

    var url = "http://localhost/Viper.ServiceAPI/api/StartingOptions/SaveTournamentDetails";
    var data = GetDefaultDataForEvent();

    var tournId = 0;

    $.ajax({
        url: url,
        type: 'POST',
        async: false,
        dataType: "json",
        contenttype: "application/json; charset=utf-8",
        data: data,
        success: function (d) {

            tournId = d;
        },
        error: function () {

            alertify.error('Error occurred while creating new tournament', 'DB Error');
            return false;
        }
    });

    window.location.href = "../Viper.Web/Users/StartingOptions.aspx?" + EncryptValue('tournId=' + tournId);
}
function GetDefaultDataForEvent() {

    //get the values from the db using ajax
    var url = "http://localhost/Viper.ServiceAPI/api/Defaults/GetDefaultDetails?siteId=" + localStorage.siteID;

    var eventData = {};

    $.ajax({
        url: url,
        type: 'post',
        datatype: "json",
        async: false,
        success: function (data) {

            eventData = {
                EndDate: data.EndDate,
                StartTime1: data.StartTime1,
                StartTime2: data.StartTime2,
                TimeInc1: data.TimeInc1,
                TimeInc2: data.TimeInc2,
                Holes: data.Holes,
                TotalPlayers: data.TotalPlayers,
                TeamSize: data.PlayersInTeam,
                Flights: data.Flights,
                SiteId: localStorage.siteID
            };

        },
        error: function () {

            alertify.error("Error occured while fetching site defaults", "DB Error");
        }
    });

    return eventData;
}

function ShowEventList() {
    window.open("../Viper.Web/Admin/NewSite.aspx?" + EncryptValue('source=lb'), "_self");
}

function EncryptValue(sData) {

    if (sData.split('=')[1] != null) {
        sData = base64.encode(sData);
    }

    return sData;
}

