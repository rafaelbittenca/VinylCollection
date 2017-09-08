function initMap() {
    // Map options
    var options = {
        zoom: 9,
        //43.6565353,-79.6010328
        center: { lat: 43.6565353, lng: -79.6010328 },
        // How you would like to style the map. 
        scrollwheel: false,
        styles: [
                 { "featureType": "administrative.land_parcel", "elementType": "all", "stylers": [{ "visibility": "off" }] },
                 { "featureType": "landscape.man_made", "elementType": "all", "stylers": [{ "visibility": "off" }] },
                 { "featureType": "poi", "elementType": "labels", "stylers": [{ "visibility": "off" }] },
                 { "featureType": "road", "elementType": "labels", "stylers": [{ "visibility": "simplified" }, { "lightness": 20 }]},
                 { "featureType": "road.highway", "elementType": "geometry", "stylers": [{ "hue": "#f49935" }] },
                 { "featureType": "road.highway", "elementType": "labels", "stylers": [{ "visibility": "simplified" }] },
                 { "featureType": "road.arterial", "elementType": "geometry", "stylers": [{ "hue": "#fad959" }] },
                 { "featureType": "road.arterial", "elementType": "labels", "stylers": [{ "visibility": "off" }] },
                 { "featureType": "road.local", "elementType": "geometry", "stylers": [{ "visibility": "simplified" }] },
                 { "featureType": "road.local", "elementType": "labels", "stylers": [{ "visibility": "simplified" }] },
                 { "featureType": "transit", "elementType": "all", "stylers": [{ "visibility": "off" }] },
                 { "featureType": "water", "elementType": "all", "stylers": [{ "hue": "#a1cdfc" }, { "saturation": 30 }, { "lightness": 49 }] }
                ]
    }

    // New map
    var map = new google.maps.Map(document.getElementById('map'), options);

    // Listen for click on map
    google.maps.event.addListener(map, 'click', function (event) {
        // Add marker
        addMarker({ coords: event.latLng });
    });

    // Array of markers
    var markers = [
      {
          //43.7068995,-79.3942168
          coords: { lat: 43.7068369, lng: -79.3924102 }, 
          content: '<h1>Home</h1>'
      }
      //,
      //{
      //    coords: { lat: -27.45245021, lng: -48.37864727 },
      //    iconImage: 'https://developers.google.com/maps/documentation/javascript/examples/full/images/beachflag.png',
      //    content: '<h1>XXX</h1>'
      //}
    ];

    // Loop through markers
    for (var i = 0; i < markers.length; i++) {
        // Add marker
        addMarker(markers[i]);
    }

    // Add Marker Function
    function addMarker(props) {
        var marker = new google.maps.Marker({
            position: props.coords,
            map: map,
            //icon:props.iconImage
        });

        // Check for customicon
        if (props.iconImage) {
            // Set icon image
            marker.setIcon(props.iconImage);
        }

        // Check content
        if (props.content) {
            var infoWindow = new google.maps.InfoWindow({
                content: props.content
            });

            marker.addListener('click', function () {
                infoWindow.open(map, marker);
            });
        }
    }
}