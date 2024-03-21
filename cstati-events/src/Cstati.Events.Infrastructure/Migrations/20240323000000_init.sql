-- +goose Up
-- +goose StatementBegin
CREATE TABLE events
(
    id                TEXT      NOT NULL,
    name              TEXT      NOT NULL,
    location          TEXT,
    status            TEXT      NOT NULL,
    data              BYTEA     NOT NULL,
    is_deleted        BOOLEAN   NOT NULL DEFAULT FALSE,
    concurrency_token TIMESTAMP NOT NULL DEFAULT (CURRENT_TIMESTAMP AT TIME ZONE 'utc'),
    PRIMARY KEY (id)
);
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
-- +goose StatementEnd
