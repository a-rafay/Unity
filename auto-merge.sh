#!/bin/sh
# Automatically merge the last commit through the following branches:
# Paranoid -} master

CURRENT_BRANCH=$(git rev-parse --abbrev-ref HEAD)
LAST_COMMIT=$(git rev-list -1 HEAD)

echo Automatically merging commit $LAST_COMMIT from $CURRENT_BRANCH rippling to master

case $CURRENT_BRANCH in
Paranoid)
  git checkout master && git merge Paranoid
  git checkout $CURRENT_BRANCH
  ;;
esac
